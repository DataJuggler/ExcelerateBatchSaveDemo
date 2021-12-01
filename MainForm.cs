

#region using statements

using DataJuggler.Win.Controls;
using DataJuggler.Excelerate;
using DataJuggler.UltimateHelper;
using DataJuggler.UltimateHelper.Objects;

#endregion

namespace DataFields
{

    #region class MainForm
    /// <summary>
    /// This class is the MainForm for this app.
    /// </summary>
    public partial class MainForm : Form
    {
        
        #region Private Variables
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'MainForm' object.
        /// </summary>
        public MainForm()
        {
            // Create Controls
            InitializeComponent();
        }
        #endregion
        
        #region Events
            
            #region LoadDataButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'LoadDataButton' is clicked.
            /// </summary>
            private void LoadDataButton_Click(object sender, EventArgs e)
            {
                // Get the text
                string path = FileBrowser.Text;

                // locals
                List<PropData> propData;
                List<Prop> props;
                BatchItem batchItem = null;
                BatchItem batchItem2 = null;
                BatchItem batchItem3 = null;
                bool saved = false;
                int count = 0;
                Row newRow = null;
                Prop newProp = null;
                
                // start at 1 here, because this is the row number for export, and with a header row we need to skip 1
                int propNumber = 1;

                // create the delimiter
                char[] delimiter = new char[] { ':' };

                // load the sheet
                Workbook workbook = ExcelDataLoader.LoadAllData(path);

                // Create a new instance of a 'Batch' object.
                Batch batch = new Batch();

                // If the workbook object exists
                if ((NullHelper.Exists(workbook)) && (ListHelper.HasOneOrMoreItems(workbook.Worksheets)))
                {
                    // get the first worksheet
                    Worksheet worksheet = workbook.Worksheets[0];

                    // load the propData
                    propData = PropData.Load(worksheet);

                    // If the propData collection exists and has one or more items
                    if (ListHelper.HasOneOrMoreItems(propData))
                    {
                        // Create a new instance of a 'BatchItem' object.
                        batchItem = new BatchItem();

                        // Set the worksheetInfo
                        batchItem.WorksheetInfo = worksheet.WorksheetInfo;

                        // Iterate the collection of PropData objects
                        foreach (PropData prop in propData)
                        {
                            // get the data field
                            string temp = prop.Data;

                            // get the words
                            List<Word> words = TextHelper.GetWords(temp, delimiter);

                            // if there are two or more words
                            if (ListHelper.HasXOrMoreItems(words, 2))
                            {
                                // Set the Field
                                prop.Field = words[0].Text.Trim();

                                // Set the Value
                                prop.Value = words[1].Text.Trim();

                                // find the row
                                Row row = worksheet.Rows.FirstOrDefault(x => x.Id == prop.RowId);

                                // If the row object exists
                                if (NullHelper.Exists(row))
                                {
                                    // Save the prop
                                    prop.Save(row);

                                    // Add this row
                                    batchItem.Updates.Add(row);
                                }
                            }
                        }
                    }

                    // Add this batchItem
                    batch.BatchItems.Add(batchItem);

                    // phase 2 is now to load the Prop sheet's data                        
                    Worksheet worksheet2 = workbook.Worksheets[1];

                    // load the props (this will be empty at this point
                    props = Prop.Load(worksheet2);

                    // If the propData collection exists and has one or more items
                    if (ListHelper.HasOneOrMoreItems(propData))
                    {
                        // Create a new BatchItem object
                        batchItem2 = new BatchItem();

                        // Set the WorksheetInfo
                        batchItem2.WorksheetInfo = worksheet2.WorksheetInfo;

                        // Iterate the collection of PropData objects
                        foreach (PropData prop in propData)
                        {
                            // increment the value for count
                            count++;

                            // used to determine if a new record is required
                            int mod = count % 6;

                            // Determine the action by the mod
                            switch (mod)
                            {
                                case 1:

                                    // Increment the value for propNumber
                                    propNumber++;

                                    // create a new row
                                    newRow = Prop.NewRow(propNumber);

                                    // Create a new prop
                                    newProp = new Prop();

                                    // now set the properties
                                    newProp.Name = prop.Value;

                                    // required
                                    break;

                                case 2:

                                    // PositionX
                                    newProp.PositionX = NumericHelper.ParseDouble(prop.Value, 0, -1);

                                    // required
                                    break;

                                case 3:

                                    // Position Y
                                    newProp.PositionY = NumericHelper.ParseDouble(prop.Value, 0, -1);

                                    // required
                                    break;

                                case 4:

                                    // Position Z
                                    newProp.PositionZ = NumericHelper.ParseDouble(prop.Value, 0, -1);

                                    // required
                                    break;

                                case 5:

                                    // if the number ends with a .0
                                    if (prop.Value.ToString().EndsWith(".0"))
                                    {
                                        // replace out the .0, messes up the parse integer
                                        prop.Value = prop.Value.Replace(".0", "");
                                    }

                                    // now set the properties
                                    newProp.CurrentTime = NumericHelper.ParseInteger(prop.Value, 0, -1);

                                    // required
                                    break;

                                case 0:

                                    // now set the properties
                                    newProp.Direction = NumericHelper.ParseInteger(prop.Value, 0, -1);

                                    // now save
                                    newRow = newProp.Save(newRow);

                                    // Add this row
                                    worksheet2.Rows.Add(newRow);

                                    // Add this update
                                    batchItem2.Updates.Add(newRow);

                                    // Add this prop
                                    props.Add(newProp);

                                    // required
                                    break;
                            }
                        }

                        // Add this batch
                        batch.BatchItems.Add(batchItem2);
                    }

                    // If the props collection exists and has one or more items
                    if (ListHelper.HasOneOrMoreItems(props))
                    {
                        // reset
                        count = 1;

                        // sort by Name
                        props = props.OrderBy(x => x.Name).ThenBy(x => x.CurrentTime).ToList();

                        // get the first worksheet
                        Worksheet worksheet3 = workbook.Worksheets[2];

                        // create a new BatchItem
                        batchItem3 = new BatchItem();

                        // Set the WorksheetInfo
                        batchItem3.WorksheetInfo = worksheet3.WorksheetInfo;

                        // Iterate the collection of Prop objects
                        foreach (Prop prop in props)
                        {
                            // reset
                            count++;

                            // sort this prop
                            PropSorted propSorted = new PropSorted();

                            // set each property
                            propSorted.Name = prop.Name;
                            propSorted.PositionX = prop.PositionX;
                            propSorted.PositionY = prop.PositionY;
                            propSorted.PositionZ = prop.PositionZ;
                            propSorted.CurrentTime = prop.CurrentTime;
                            propSorted.Direction = prop.Direction;

                            // create a new row
                            Row row = PropSorted.NewRow(count);

                            // Save the data to the Row
                            row = propSorted.Save(row);

                            // Add this item
                            batchItem3.Updates.Add(row);
                        }

                        // Add this BatchItem
                        batch.BatchItems.Add(batchItem3);
                    }

                    // if there are one or more rows to update
                    if ((NullHelper.Exists(batch)) && (ListHelper.HasOneOrMoreItems(batch.BatchItems)))
                    {
                        // Save this batch
                        saved = ExcelHelper.SaveBatch(path, batch);

                        // if the value for saved is true
                        if (saved)
                        {
                            StatusLabel.Text = "Saved";
                        }
                        else
                        {
                            StatusLabel.Text = "Save Failed";
                        }
                    }
                }
            }
            #endregion

        #endregion

        
    }
    #endregion

}
