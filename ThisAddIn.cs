using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;

namespace FirstExcelAddIn_2019_10_29
{/* A partial definition of the ThisAddIn class. This class provides an entry point for your code and provides access to the object model of Excel. 
    For more information, see Program VSTO Add-ins. The remainder of the ThisAddIn class is defined in a hidden code file that you should not modify */

    /* A partial definition of the ThisAddIn class. This class provides an entry point for your code and provides access to the object model of Excel. 
    For more information, see Program VSTO Add-ins. The remainder of the ThisAddIn class is defined in a hidden code file that you should not modify */
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            /* used to connect the Application_WorkbookBeforeSave event handler with the WorkbookBeforeSave event    */
            /* The Application field returns a Application object, which represents the current instance of Excel. */
            this.Application.WorkbookBeforeSave += new Microsoft.Office.Interop.Excel.AppEvents_WorkbookBeforeSaveEventHandler(Application_WorkbookBeforeSave);
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }
        void Application_WorkbookBeforeSave(Microsoft.Office.Interop.Excel.Workbook Wb, bool SaveAsUI, ref bool Cancel)
        {
            /* an event handler for the WorkbookBeforeSave event, which is raised when a workbook is saved.
            When the user saves a workbook, the event handler adds new text at the start of the active worksheet */
            /* The Wb parameter is a Workbook object, which represents the saved workbook */
            Excel.Worksheet activeWorksheet = ((Excel.Worksheet)Application.ActiveSheet);
            Excel.Range firstRow = activeWorksheet.get_Range("A1");
            firstRow.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range newFirstRow = activeWorksheet.get_Range("A1");
            newFirstRow.Value2 = "This text was added by using code";
        }
        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
