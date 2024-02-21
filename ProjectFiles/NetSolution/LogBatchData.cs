#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.NetLogic;
using FTOptix.CoreBase;
using FTOptix.NativeUI;
using FTOptix.UI;
using FTOptix.SQLiteStore;
using FTOptix.Store;
using FTOptix.Core;
using FTOptix.WebUI;
using FTOptix.DataLogger;
#endregion

public class LogBatchData : BaseNetLogic
{
    [ExportMethod]
    public void BatchDataLogging()
    {

        Project.Current.GetVariable("Model/BatchData/BatchStopTime").Value = DateTime.Now;
        

        Store myStore = Project.Current.Get<Store>("DataStores/EDB_Batch_Report");
        SQLiteStore myBatchStore = (SQLiteStore)Project.Current.Get<Store>("DataStores/EDB_Batch_Report");
        SQLiteStore myAlarmStore = (SQLiteStore)Project.Current.Get<Store>("DataStores/EDB_Alarm_History");
        SQLiteStore myProductionStore = (SQLiteStore)Project.Current.Get<Store>("DataStores/EDB_Prod_Report");
        SQLiteStore myAuditStore = (SQLiteStore)Project.Current.Get<Store>("DataStores/EDB_AuditTrail");
        Table myTable = myStore.Tables.Get<Table>("BatchInfo");
        UAVariable BatchBackupPath = (UAVariable)Project.Current.Get("Model/Retain_Variable/BatchDBBackupFileName");
        UAVariable AlarmBackupPath = (UAVariable)Project.Current.Get("Model/Retain_Variable/AlarmDBBackupFileName");
        UAVariable ProductionBackupPath = (UAVariable)Project.Current.Get("Model/Retain_Variable/ProductionDBBackupFileName");
        UAVariable AuditBackupPath = (UAVariable)Project.Current.Get("Model/Retain_Variable/AuditDBBackupFileName");
        
        string batchno = Project.Current.GetVariable("Model/BatchData/BatchNumber").Value;
        DateTime batchstart = Project.Current.GetVariable("Model/BatchData/BatchStartTime").Value;
        DateTime batchstop = Project.Current.GetVariable("Model/BatchData/BatchStopTime").Value;
        string prodname = Project.Current.GetVariable("Model/BatchData/ProductName").Value;
        int totalcount = Project.Current.GetVariable("Model/BatchData/TotalCounts").Value;
        int rejectcount = Project.Current.GetVariable("Model/BatchData/RejectCounts").Value;
        int goodcount = Project.Current.GetVariable("Model/BatchData/GoodCounts").Value;
        float minspd = Project.Current.GetVariable("Model/BatchData/MachineMinSpeed").Value;
        float maxspd = Project.Current.GetVariable("Model/BatchData/MachineMaxSpeed").Value;
        float setspd = Project.Current.GetVariable("Model/BatchData/SetSpeed").Value;
        float cs3settmp = Project.Current.GetVariable("Model/BatchData/CS3_Set_Temperature").Value;
        float cs1settmp = Project.Current.GetVariable("Model/BatchData/CS1_Set_Temperature").Value;
        float cs2settmp = Project.Current.GetVariable("Model/BatchData/CS2_Set_Temperature").Value;
        float uj1settmp = Project.Current.GetVariable("Model/BatchData/UJ1_Set_Temperature").Value;
        float lj1settmp = Project.Current.GetVariable("Model/BatchData/LJ1_Set_Temperature").Value;
        float cs3mintmp = Project.Current.GetVariable("Model/BatchData/CS3_Min_Temperature").Value;
        float cs1mintmp = Project.Current.GetVariable("Model/BatchData/CS1_Min_Temperature").Value;
        float cs2mintmp = Project.Current.GetVariable("Model/BatchData/CS2_Min_Temperature").Value;
        float uj1mintmp = Project.Current.GetVariable("Model/BatchData/UJ1_Min_Temperature").Value;
        float lj1mintmp = Project.Current.GetVariable("Model/BatchData/LJ1_Min_Temperature").Value;
        float cs3maxtmp = Project.Current.GetVariable("Model/BatchData/CS3_Max_Temperature").Value;
        float cs1maxtmp = Project.Current.GetVariable("Model/BatchData/CS1_Max_Temperature").Value;
        float cs2maxtmp = Project.Current.GetVariable("Model/BatchData/CS2_Max_Temperature").Value;
        float uj1maxtmp = Project.Current.GetVariable("Model/BatchData/UJ1_Max_Temperature").Value;
        float lj1maxtmp = Project.Current.GetVariable("Model/BatchData/LJ1_Max_Temperature").Value;
        


          



        object[,] rawValues = new object [1,26]; // [Raw, Column]; Column = number columns in Table of Audit event logger  database 
        rawValues[0,0] = DateTime.Now;
        rawValues[0,1] = batchno;
        rawValues[0,2] = batchstart;
        rawValues[0,3] = batchstop;
        rawValues[0,4] = prodname;
        rawValues[0,5] = totalcount;
        rawValues[0,6] = rejectcount;
        rawValues[0,7] = goodcount;
        rawValues[0,8] = minspd;
        rawValues[0,9] = maxspd;
        rawValues[0,10] = setspd;
        rawValues[0,11] = cs3settmp;
        rawValues[0,12] = cs1settmp;
        rawValues[0,13] = cs2settmp;
        rawValues[0,14] = uj1settmp;
        rawValues[0,15] = lj1settmp;
        rawValues[0,16] = cs3mintmp;
        rawValues[0,17] = cs1mintmp;
        rawValues[0,18] = cs2mintmp;
        rawValues[0,19] = uj1mintmp;
        rawValues[0,20] = lj1mintmp;
        rawValues[0,21] = cs3maxtmp;
        rawValues[0,22] = cs1maxtmp;
        rawValues[0,23] = cs2maxtmp;
        rawValues[0,24] = uj1maxtmp;
        rawValues[0,25] = lj1maxtmp;

        
        string[] columns = new string[26] {"LocalTimeStamp", "BatchNumber", "BatchStartTime", "BatchStopTime", "ProductName", "TotalCounts", "RejectCounts", "GoodCounts", "MachineMinSpeed", "MachineMaxSpeed", "SetSpeed", "CS3_Set_Temperature", "CS1_Set_Temperature", "CS2_Set_Temperature", "UJ1_Set_Temperature", "LJ1_Set_Temperature", "CS3_Min_Temperature", "CS1_Min_Temperature", "CS2_Min_Temperature", "UJ1_Min_Temperature", "LJ1_Min_Temperature", "CS3_Max_Temperature", "CS1_Max_Temperature", "CS2_Max_Temperature", "UJ1_Max_Temperature", "LJ1_Max_Temperature"};
        myTable.Insert(columns,rawValues);

        Project.Current.GetVariable("Model/BatchData/BatchRunning").Value = false;

       // myBatchStore.Backup(ResourceUri.FromAbsoluteFilePath(BatchBackupPath.Value));
       // myAlarmStore.Backup(ResourceUri.FromAbsoluteFilePath(AlarmBackupPath.Value));
      //  myProductionStore.Backup(ResourceUri.FromAbsoluteFilePath(ProductionBackupPath.Value));
       // myAuditStore.Backup(ResourceUri.FromAbsoluteFilePath(AuditBackupPath.Value));
    }
}
