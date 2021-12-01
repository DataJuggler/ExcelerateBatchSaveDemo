

#region using statements

using DataJuggler.Excelerate;
using DataJuggler.Net5;
using DataJuggler.UltimateHelper;
using System;
using System.Collections.Generic;

#endregion

namespace DataFields
{

    #region class PropData
    public class PropData
    {

        #region Private Variables
        private string data;
        private string field;
        private Guid rowId;
        private string _value;
        #endregion

        #region Methods

            #region Load(Row row)
            /// <summary>
            /// This method loads a PropData object from a Row.
            /// </Summary>
            /// <param name="row">The row which the row.Columns[x].ColumnValue will be used to load this object.</param>
            public void Load(Row row)
            {
                // If the row exists and the row's column collection exists
                if ((NullHelper.Exists(row)) && (row.HasColumns))
                {
                    Data = row.Columns[0].StringValue;
                    Field = row.Columns[1].StringValue;
                    Value = row.Columns[2].StringValue;
                }

                // Set RowId
                RowId = row.Id;
            }
            #endregion

            #region Load(Worksheet worksheet)
            /// <summary>
            /// This method loads a list of PropData objects from a Worksheet.
            /// </Summary>
            /// <param name="worksheet">The worksheet which the rows collection will be used to load a list of PropData objects.</param>
            public static List<PropData> Load(Worksheet worksheet)
            {
                // Initial value
                List<PropData> propDataList = new List<PropData>();
                
                // If the worksheet exists and the row's collection exists
                if ((NullHelper.Exists(worksheet)) && (worksheet.HasRows))
                {
                    // Iterate the worksheet.Rows collection
                    foreach (Row row in worksheet.Rows)
                    {
                        // If the row is not a HeaderRow and row's column collection exists
                        if ((!row.IsHeaderRow) && (row.HasColumns))
                        {
                            // Create a new instance of a PropData object.
                            PropData propData = new PropData();
                            
                            // Load this object
                            propData.Load(row);
                            
                            // Add this object to the list
                            propDataList.Add(propData);
                        }
                    }
                }
                
                // return value
                return propDataList;
            }
            #endregion

            #region NewRow(Row row)
            /// <summary>
            /// This method creates the columns for the row to save a new PropData object.
            /// </Summary>
            /// <param name="row">The row which the Columns will be created for.</param>
            public static Row NewRow(int rowNumber)
            {
                // initial value
                Row newRow = new Row();

                // Create Column
                Column dataColumn = new Column("Data", rowNumber, 1, DataManager.DataTypeEnum.String);

                // Add this column
                newRow.Columns.Add(dataColumn);

                // Create Column
                Column fieldColumn = new Column("Field", rowNumber, 2, DataManager.DataTypeEnum.String);

                // Add this column
                newRow.Columns.Add(fieldColumn);

                // Create Column
                Column valueColumn = new Column("Value", rowNumber, 3, DataManager.DataTypeEnum.String);

                // Add this column
                newRow.Columns.Add(valueColumn);

                // return value
                return newRow;
            }
            #endregion

            #region Save(Row row)
            /// <summary>
            /// This method saves a PropData object back to a Row.
            /// </Summary>
            /// <param name="row">The row which the row.Columns[x].ColumnValue will be set to Save back to Excel.</param>
            public Row Save(Row row)
            {
                // If the row exists and the row's column collection exists
                if ((NullHelper.Exists(row)) && (row.HasColumns))
                {
                    row.Columns[0].ColumnValue = Data;
                    row.Columns[1].ColumnValue = Field;
                    row.Columns[2].ColumnValue = Value;
                }

                // return value
                return row;
            }
            #endregion

        #endregion

        #region Properties

            #region string Data
            public string Data
            {
                get
                {
                    return data;
                }
                set
                {
                    data = value;
                }
            }
            #endregion

            #region string Field
            public string Field
            {
                get
                {
                    return field;
                }
                set
                {
                    field = value;
                }
            }
            #endregion

            #region Guid RowId
            public Guid RowId
            {
                get
                {
                    return rowId;
                }
                set
                {
                    rowId = value;
                }
            }
            #endregion

            #region string Value
            public string Value
            {
                get
                {
                    return _value;
                }
                set
                {
                    _value = value;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}