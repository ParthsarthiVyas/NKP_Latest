#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.Retentivity;
using FTOptix.UI;
using FTOptix.RAEtherNetIP;
using FTOptix.NativeUI;
using FTOptix.CoreBase;
using FTOptix.CommunicationDriver;
using FTOptix.Core;
using FTOptix.NetLogic;
using FTOptix.AuditSigning;
using FTOptix.Store;
using FTOptix.ODBCStore;
using FTOptix.EventLogger;
using FTOptix.SQLiteStore;
using FTOptix.DataLogger;
using FTOptix.Alarm;
using FTOptix.Recipe;
using FTOptix.Report;
using FTOptix.MicroController;
#endregion

public class mm_dd_yyyy_clock1 : BaseNetLogic
{
    public override void Start()
    {
        periodicTask = new PeriodicTask(UpdateTime, 1000, LogicObject);
        periodicTask.Start();
    }

    public override void Stop()
    {
        periodicTask.Dispose();
        periodicTask = null;
    }

    private void UpdateTime()
    {
        int YearVar = DateTime.Now.Year;
        int MonthVar = DateTime.Now.Month;
        int DayVar = DateTime.Now.Day;
        int Dayhour = DateTime.Now.Hour;
        int Dayminute = DateTime.Now.Minute;
        DateTime datetime1 = DateTime.Now;

        // Format date as "dd/MM/yyyy"
      //  string formattedLocalDate = DayVar + "/" + MonthVar + "/" + YearVar;
        // string formattedLocalDate = DateTime.Now.ToString("dd/MM/yyyy");
        string formattedLocalDate = $"{DayVar:D2}/{MonthVar:D2}/{YearVar}";



        //Format time in 24-hour format
        // string formattedLocalTime = datetime1.ToString("HH:mm:ss");
        string formattedLocalTime = DateTime.Now.ToString("HH:mm:ss");
          LogicObject.GetVariable("datetime").Value = formattedLocalDate + " " + formattedLocalTime;
     
     
        // 	throw new Exception("datetime");
    }

    private PeriodicTask periodicTask;
}
