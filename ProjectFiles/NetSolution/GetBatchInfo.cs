#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.NetLogic;
using FTOptix.CoreBase;
using FTOptix.NativeUI;
using FTOptix.UI;
using FTOptix.Store;
using FTOptix.Core;
using FTOptix.WebUI;
using FTOptix.SQLiteStore;
using FTOptix.MicroController;
using FTOptix.CommunicationDriver;
using FTOptix.RAEtherNetIP;
using FTOptix.DataLogger;
#endregion

public class GetBatchInfo : BaseNetLogic
{
    public override void Start()
    {
        SelBatchNoVar = Project.Current.GetVariable("Model/BatchData/ReportData/SelectedBatchNumber");
        SelBatchNoVar.VariableChange += SelBatchNoVar_VariableChange;

        LoadBatchInfo();
    }

    private void SelBatchNoVar_VariableChange(object sender, VariableChangeEventArgs e)
    {
        LoadBatchInfo();
    }

    private void LoadBatchInfo()
    {
        var myStore = Project.Current.Get<Store>("DataStores/EDB_Batch_Report");
        string batchsquery = Project.Current.GetVariable("Model/BatchData/ReportData/BatchSQLQuery").Value;
        //Log.Warning(batchsquery);
        myStore.Query(batchsquery, out string[] header, out object[,] resultSet);
        //int LastVal = resultSet.GetLength(0) - 1;
        //Log.Warning("Number Results = " + resultSet.GetLength(0));

        string batchno = "";
        DateTime batchstart = default;
        DateTime batchstop = default;
        string prodname = "";
        int totalcnts = 0;
        int rejectcnts = 0;
        int goodcnts = 0;
        float minspd = 0F;
        float maxspd = 0F;
        float setspd = 0F;
        float cs3settmp = 0F;
        float cs1settmp = 0F;
        float cs2settmp = 0F;
        float uj1settmp = 0F;
        float lj1settmp = 0F;
        float cs3mintmp = 0F;
        float cs1mintmp = 0F;
        float cs2mintmp = 0F;
        float uj1mintmp = 0F;
        float lj1mintmp = 0F;
        float cs3maxtmp = 0F;
        float cs1maxtmp = 0F;
        float cs2maxtmp = 0F;
        float uj1maxtmp = 0F;
        float lj1maxtmp = 0F;


        
        if (resultSet.GetLength(0) > 0)
        {
            batchno = resultSet[0,0].ToString();
            batchstart = DateTime.Parse(resultSet[0,1].ToString());
            batchstop = DateTime.Parse(resultSet[0,2].ToString());
            prodname = resultSet[0,3].ToString();
            totalcnts = int.Parse(resultSet[0,4].ToString());
            rejectcnts = int.Parse(resultSet[0,5].ToString());
            goodcnts = int.Parse(resultSet[0,6].ToString());
            minspd = float.Parse(resultSet[0,7].ToString());
            maxspd = float.Parse(resultSet[0,8].ToString());
            setspd = float.Parse(resultSet[0,9].ToString());
            cs3settmp = float.Parse(resultSet[0,10].ToString());
            cs1settmp = float.Parse(resultSet[0,11].ToString());
            cs2settmp = float.Parse(resultSet[0,12].ToString());
            uj1settmp = float.Parse(resultSet[0,13].ToString());
            lj1settmp = float.Parse(resultSet[0,14].ToString());
            cs3mintmp = float.Parse(resultSet[0,15].ToString()); 
            cs1mintmp = float.Parse(resultSet[0,16].ToString()); 
            cs2mintmp = float.Parse(resultSet[0,17].ToString()); 
            uj1mintmp = float.Parse(resultSet[0,18].ToString()); 
            lj1mintmp = float.Parse(resultSet[0,19].ToString()); 
            cs3maxtmp = float.Parse(resultSet[0,20].ToString()); 
            cs1maxtmp = float.Parse(resultSet[0,21].ToString()); 
            cs2maxtmp = float.Parse(resultSet[0,22].ToString()); 
            uj1maxtmp = float.Parse(resultSet[0,23].ToString()); 
            lj1maxtmp = float.Parse(resultSet[0,24].ToString());           

            
        }
        
        Project.Current.GetVariable("Model/BatchData/ReportData/BatchNumber").Value = batchno;
        Project.Current.GetVariable("Model/BatchData/ReportData/BatchStartTime").Value = batchstart;
        Project.Current.GetVariable("Model/BatchData/ReportData/BatchStopTime").Value = batchstop;
        Project.Current.GetVariable("Model/BatchData/ReportData/ProductName").Value = prodname;
        Project.Current.GetVariable("Model/BatchData/ReportData/TotalCounts").Value = totalcnts;
        Project.Current.GetVariable("Model/BatchData/ReportData/RejectCounts").Value = rejectcnts;
        Project.Current.GetVariable("Model/BatchData/ReportData/GoodCounts").Value = goodcnts;
        Project.Current.GetVariable("Model/BatchData/ReportData/MachineMinSpeed").Value = minspd;
        Project.Current.GetVariable("Model/BatchData/ReportData/MachineMaxSpeed").Value = maxspd;
        Project.Current.GetVariable("Model/BatchData/ReportData/SetSpeed").Value = setspd;
        Project.Current.GetVariable("Model/BatchData/ReportData/CS3_Set_Temperature").Value = cs3settmp;
        Project.Current.GetVariable("Model/BatchData/ReportData/CS1_Set_Temperature").Value = cs1settmp;
        Project.Current.GetVariable("Model/BatchData/ReportData/CS2_Set_Temperature").Value = cs2settmp;
        Project.Current.GetVariable("Model/BatchData/ReportData/UJ1_Set_Temperature").Value = uj1settmp;
        Project.Current.GetVariable("Model/BatchData/ReportData/LJ1_Set_Temperature").Value = lj1settmp;
        Project.Current.GetVariable("Model/BatchData/ReportData/CS3_Min_Temperature").Value = cs3mintmp;
        Project.Current.GetVariable("Model/BatchData/ReportData/CS1_Min_Temperature").Value = cs1mintmp;
        Project.Current.GetVariable("Model/BatchData/ReportData/CS2_Min_Temperature").Value = cs2mintmp;
        Project.Current.GetVariable("Model/BatchData/ReportData/UJ1_Min_Temperature").Value = uj1mintmp;
        Project.Current.GetVariable("Model/BatchData/ReportData/LJ1_Min_Temperature").Value = lj1mintmp;
        Project.Current.GetVariable("Model/BatchData/ReportData/CS3_Max_Temperature").Value = cs3maxtmp;
        Project.Current.GetVariable("Model/BatchData/ReportData/CS1_Max_Temperature").Value = cs1maxtmp;
        Project.Current.GetVariable("Model/BatchData/ReportData/CS2_Max_Temperature").Value = cs2maxtmp;
        Project.Current.GetVariable("Model/BatchData/ReportData/UJ1_Max_Temperature").Value = uj1maxtmp;
        Project.Current.GetVariable("Model/BatchData/ReportData/LJ1_Max_Temperature").Value = lj1maxtmp;




    }

    private IUAVariable SelBatchNoVar;
}
