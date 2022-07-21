namespace Hackathon.Api;

using Azure;
using Azure.Data.Tables;
using Hackathon.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Collections.Generic;

public class Repository : IRepository {
    private readonly IConfiguration Configuration;
    private TableClient _tableClient;

    public Repository(IConfiguration configuration)
    {
        Configuration = configuration;
        
        var storageUri = "https://tmoonetouch.table.core.windows.net/";
        var tableName = "deviceData";
        var storageAccountKey = Configuration["StorageAccountAccessKey"];
        
        _tableClient = new TableClient(
            new Uri(storageUri),
            tableName,
            new TableSharedKeyCredential(accountName, storageAccountKey));
    }

    public Task<HttpResponseMessage> CreateAlert(RequestModel request) {

        var rowKey = new Guid.NewGuid();
        var partitionKey = request.DeviceId;

        var entity = new TableEntity(partitionKey, rowKey) { request };

        _tableClient.AddEntity(entity);

        return HttpResponseMessage.Ok;
    }

    public Task<List<ResponseModel>> GetAlerts() {

        Pageable<ResponseModel> queryResponse = _tableClient.Query<ResponseModel>();
        List<ResponseModel> responseList = new List<ResponseModel>();

        foreach (var response in queryResponse) {
            responseList.Add(response);
        }

        return responseList;
    }
}