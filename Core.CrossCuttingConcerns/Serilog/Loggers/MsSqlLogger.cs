﻿using Core.CrossCuttingConcerns.Serilog.ConfigurationModels;
using Core.CrossCuttingConcerns.Serilog.Messages;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Configuration;

namespace Core.CrossCuttingConcerns.Serilog.Loggers;
public class MsSqlLogger : LoggerServiceBase
{
    private readonly IConfiguration _configuration;
    public MsSqlLogger(IConfiguration configuration)
    {
        _configuration = configuration;

        MsSqlConfiguration logConfig =
            configuration.GetSection("SeriLogConfigurations:MsSqlConfiguration").Get<MsSqlConfiguration>()
            ?? throw new Exception(SerilogMessages.NullOptionsMessage);

        MSSqlServerSinkOptions sinkOptions = new MSSqlServerSinkOptions
        {
            TableName = logConfig.TableName,
            AutoCreateSqlTable = logConfig.AutoCreateSqlTable,
            AutoCreateSqlDatabase = logConfig.AutoCreateSqlTable,
        };

        ColumnOptions columnOptions = new();

        global::Serilog.Core.Logger seriLogConfig = new LoggerConfiguration()
            .WriteTo.MSSqlServer(logConfig.ConnectionString, sinkOptions, columnOptions: columnOptions)
            .CreateLogger();

        Logger = seriLogConfig;
          
    }

}
