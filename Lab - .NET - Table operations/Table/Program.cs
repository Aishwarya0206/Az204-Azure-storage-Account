
using Azure.Data.Tables;
using Azure;

string connectionString = "DefaultEndpointsProtocol=https;AccountName=azstorageacc204;AccountKey=nLuryKPom7fJ5d4cIyFN/u8D4zQb70wJGckfrBH6sowYpTwdAkUIfeEAtg19RwNSYHknZfiHTMI4+AStuMSyfA==;EndpointSuffix=core.windows.net";
string tableName = "Orders";
int i = 1;

Console.WriteLine("Press 'Enter' to insert entities.");
Console.ReadLine();
(string partitionKey, string rowKey, int quantity)[] entities = new[]
        {
            ("O1", "Mobile", 100),
            ("O2", "Laptop", 50),
            ("O3", "Desktop", 70),
            ("O4", "Laptop", 200),
            ("O5", "Desktop", 45)
        };
foreach (var entity in entities)
{
    AddEntity(entity.partitionKey, entity.rowKey, entity.quantity);
}



string[] entitiesPartition = new[] 
        {
            ("Laptop"), 
            ("Desktop"), 
            ("Mobile")
        };
foreach (var partition in entitiesPartition)
{
    Console.WriteLine("Press 'Enter' to query entities for "+partition);
    Console.ReadLine();
    QueryEntity(partition);
}

Console.WriteLine("Press 'Enter' to delete entities");
Console.ReadLine();

Console.WriteLine("Enter partition key: ");
string partitionKey = Console.ReadLine();

Console.WriteLine("Enter the order id: ");
string orderID = Console.ReadLine();
DeleteEntity(partitionKey, orderID);

void AddEntity(string orderID,string category,int quantity)
{
    TableClient tableClient = new TableClient(connectionString, tableName);
    if (quantity < 100)
    {
        TableEntity tableEntity = new TableEntity(category, orderID)
        {
            {"quantity", quantity}
        };
        tableClient.AddEntity(tableEntity);
    }
    else
    {
        TableEntity tableEntity = new TableEntity(category, orderID)
        {
            {"quantity", quantity},
            {"customerid", "c0"+i}
        };
        tableClient.AddEntity(tableEntity);
        i += 1;
    }
    
    Console.WriteLine("Adding Entity with Partition Key {0} and Row Key {1}", category, orderID);
}

void QueryEntity(string category)
{
    TableClient tableClient = new TableClient(connectionString, tableName);

    Pageable<TableEntity> queryResults = tableClient.Query<TableEntity>(entity => entity.PartitionKey == category);

    Console.WriteLine("The Entities within the partition {0}", category);
    foreach (TableEntity tableEntity in queryResults)
    {
        

        Console.WriteLine("Order ID {0}",tableEntity.RowKey);
        Console.WriteLine("Quantity {0}", tableEntity.GetInt32("quantity"));
        Console.WriteLine("CustomerId {0}", tableEntity.GetString("customerid"));

    }
}

void DeleteEntity(string category,string orderID)
{
    TableClient tableClient = new TableClient(connectionString, tableName);
    tableClient.DeleteEntity(category, orderID);
    Console.WriteLine("Entity with Partition Key {0} and Row Key {1} deleted", category, orderID);
}