

#region using statements

using DataJuggler.Excelerate;
using DataJuggler.Net5;
using DataJuggler.UltimateHelper;
using System;
using System.Collections.Generic;

#endregion

namespace DataFields
{

    #region class Prop
    public class Prop
    {

        #region Private Variables
        private int currentTime;
        private int direction;
        private string name;
        private double positionX;
        private double positionY;
        private double positionZ;
        private Guid rowId;
        #endregion

        #region Methods

            #region Load(Row row)
            /// <summary>
            /// This method loads a Prop object from a Row.
            /// </Summary>
            /// <param name="row">The row which the row.Columns[x].ColumnValue will be used to load this object.</param>
            public void Load(Row row)
            {
                // If the row exists and the row's column collection exists
                if ((NullHelper.Exists(row)) && (row.HasColumns))
                {
                    Name = row.Columns[0].StringValue;
                    PositionX = (double) row.Columns[1].DecimalValue;
                    PositionY = (double) row.Columns[2].DecimalValue;
                    PositionZ = (double) row.Columns[3].DecimalValue;
                    CurrentTime = row.Columns[4].IntValue;
                    Direction = row.Columns[5].IntValue;
                }

                // Set RowId
                RowId = row.Id;
            }
            #endregion

            #region Load(Worksheet worksheet)
            /// <summary>
            /// This method loads a list of Prop objects from a Worksheet.
            /// </Summary>
            /// <param name="worksheet">The worksheet which the rows collection will be used to load a list of Prop objects.</param>
            public static List<Prop> Load(Worksheet worksheet)
            {
                // Initial value
                List<Prop> propList = new List<Prop>();
                
                // If the worksheet exists and the row's collection exists
                if ((NullHelper.Exists(worksheet)) && (worksheet.HasRows))
                {
                    // Iterate the worksheet.Rows collection
                    foreach (Row row in worksheet.Rows)
                    {
                        // If the row is not a HeaderRow and row's column collection exists
                        if ((!row.IsHeaderRow) && (row.HasColumns))
                        {
                            // Create a new instance of a Prop object.
                            Prop prop = new Prop();
                            
                            // Load this object
                            prop.Load(row);
                            
                            // Add this object to the list
                            propList.Add(prop);
                        }
                    }
                }
                
                // return value
                return propList;
            }
            #endregion

            #region NewRow(Row row)
            /// <summary>
            /// This method creates the columns for the row to save a new Prop object.
            /// </Summary>
            /// <param name="row">The row which the Columns will be created for.</param>
            public static Row NewRow(int rowNumber)
            {
                // initial value
                Row newRow = new Row();

                // Create Column
                Column nameColumn = new Column("Name", rowNumber, 1, DataManager.DataTypeEnum.String);

                // Add this column
                newRow.Columns.Add(nameColumn);

                // Create Column
                Column positionXColumn = new Column("PositionX", rowNumber, 2, DataManager.DataTypeEnum.Decimal);

                // Add this column
                newRow.Columns.Add(positionXColumn);

                // Create Column
                Column positionYColumn = new Column("PositionY", rowNumber, 3, DataManager.DataTypeEnum.Decimal);

                // Add this column
                newRow.Columns.Add(positionYColumn);

                // Create Column
                Column positionZColumn = new Column("PositionZ", rowNumber, 4, DataManager.DataTypeEnum.Decimal);

                // Add this column
                newRow.Columns.Add(positionZColumn);

                // Create Column
                Column currentTimeColumn = new Column("CurrentTime", rowNumber, 5, DataManager.DataTypeEnum.Integer);

                // Add this column
                newRow.Columns.Add(currentTimeColumn);

                // Create Column
                Column directionColumn = new Column("Direction", rowNumber, 6, DataManager.DataTypeEnum.Integer);

                // Add this column
                newRow.Columns.Add(directionColumn);

                // return value
                return newRow;
            }
            #endregion

            #region Save(Row row)
            /// <summary>
            /// This method saves a Prop object back to a Row.
            /// </Summary>
            /// <param name="row">The row which the row.Columns[x].ColumnValue will be set to Save back to Excel.</param>
            public Row Save(Row row)
            {
                // If the row exists and the row's column collection exists
                if ((NullHelper.Exists(row)) && (row.HasColumns))
                {
                    row.Columns[0].ColumnValue = Name;
                    row.Columns[1].ColumnValue = PositionX;
                    row.Columns[2].ColumnValue = PositionY;
                    row.Columns[3].ColumnValue = PositionZ;
                    row.Columns[4].ColumnValue = CurrentTime;
                    row.Columns[5].ColumnValue = Direction;
                }

                // return value
                return row;
            }
            #endregion

        #endregion

        #region Properties

            #region int CurrentTime
            public int CurrentTime
            {
                get
                {
                    return currentTime;
                }
                set
                {
                    currentTime = value;
                }
            }
            #endregion

            #region int Direction
            public int Direction
            {
                get
                {
                    return direction;
                }
                set
                {
                    direction = value;
                }
            }
            #endregion

            #region string Name
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }
            #endregion

            #region double PositionX
            public double PositionX
            {
                get
                {
                    return positionX;
                }
                set
                {
                    positionX = value;
                }
            }
            #endregion

            #region double PositionY
            public double PositionY
            {
                get
                {
                    return positionY;
                }
                set
                {
                    positionY = value;
                }
            }
            #endregion

            #region double PositionZ
            public double PositionZ
            {
                get
                {
                    return positionZ;
                }
                set
                {
                    positionZ = value;
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

        #endregion

    }
    #endregion

}