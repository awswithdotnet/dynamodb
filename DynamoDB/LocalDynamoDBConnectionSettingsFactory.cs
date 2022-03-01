using Abstractions;
using Amazon.DynamoDBv2;

namespace DynamoDB;
public class LocalDynamoDBConnectionSettingsFactory : IDataConnectionSettingsFactory<AmazonDynamoDBConfig>
{
    public AmazonDynamoDBConfig GetSettings()
    {
        AmazonDynamoDBConfig amazonDynamoDBConfig = new AmazonDynamoDBConfig();
        amazonDynamoDBConfig.ServiceURL = "http://localhost:8000";

        return amazonDynamoDBConfig;
    }
}
