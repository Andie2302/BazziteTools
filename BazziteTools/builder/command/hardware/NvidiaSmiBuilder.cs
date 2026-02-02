using BazziteTools.builder.command.@base;

namespace BazziteTools.builder.command.hardware;

public class NvidiaSmiBuilder() : LinuxCommandBuilder<NvidiaSmiBuilder>("nvidia-smi")
{
    public NvidiaSmiBuilder QueryTemperature()
    {
        AddLongOption("query-gpu", "temperature.gpu");
        AddLongOption("format", "csv,noheader,nounits");
        return this;
    }

    public NvidiaSmiBuilder QueryUsage()
    {
        AddLongOption("query-gpu", "utilization.gpu,utilization.memory");
        AddLongOption("format", "csv,noheader,nounits");
        return this;
    }

    public override CommandReport Validate()
    {
        var report = new CommandReport();
        if (!Arguments.Contains("--query-gpu"))
            report.AddWarning("Keine spezifische Abfrage gesetzt, es wird die Standard-Übersicht gezeigt.");
        return report;
    }
}