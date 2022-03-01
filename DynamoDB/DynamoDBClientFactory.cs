using Abstractions;
using Amazon.DynamoDBv2;

namespace DynamoDB;
public class DynamoDBClientFactory : IDataClientFactory<AmazonDynamoDBClient>
{
    private readonly IDataConnectionSettingsFactory<AmazonDynamoDBConfig> _dataConnectionSettingsFactory;

    public DynamoDBClientFactory(IDataConnectionSettingsFactory<AmazonDynamoDBConfig> dataConnectionSettingsFactory){
        _dataConnectionSettingsFactory = dataConnectionSettingsFactory;
    }

    public AmazonDynamoDBClient GetClient()
    {
        AmazonDynamoDBConfig amazonDynamoDBConfig = _dataConnectionSettingsFactory.GetSettings();
        AmazonDynamoDBClient client = new AmazonDynamoDBClient(amazonDynamoDBConfig);

        return client;
    }
}
