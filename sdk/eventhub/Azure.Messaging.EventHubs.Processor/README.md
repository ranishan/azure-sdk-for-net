# Azure Event Hubs Event Processor client library for .NET

Azure Event Hubs is a highly scalable publish-subscribe service that can ingest millions of events per second and stream them to multiple consumers. This lets you process and analyze the massive amounts of data produced by your connected devices and applications. Once Event Hubs has collected the data, you can retrieve, transform and store it by using any real-time analytics provider or with batching/storage adapters.  If you would like to know more about Azure Event Hubs, you may wish to review: [What is Event Hubs](https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-about)?

The Event Processor client library is a companion to the Azure Event Hubs client library, providing a stand-alone client for consuming events in a robust, durable, and scalable way that is suitable for the majority of production scenarios.  An opinionated implementation built using Azure Storage blobs, the Event Processor is recommended for:

- Reading and processing events across all partitions of an Event Hub at scale with resilience to transient failures and intermittent network issues.

- Procesing events cooperatively, where multiple processors dynamically distribute and share the responsibility in the context of a consumer group, gracefully managing the load as processors are added and removed from the group.

- Managing checkpoints and state for processing in a durable manner using Azure Storage blobs as the underlying data store.

[Source code](.) | [Package (NuGet)](https://www.nuget.org/packages/Azure.Messaging.EventHubs.Processor/) | [API reference documentation](https://azure.github.io/azure-sdk-for-net/eventhub.html) | [Product documentation](https://docs.microsoft.com/en-us/azure/event-hubs/)

## Getting started

### Prerequisites

- **Microsoft Azure Subscription:**  To use Azure services, including Azure Event Hubs, you'll need a subscription.  If you do not have an existing Azure account, you may sign up for a free trial or use your MSDN subscriber benefits when you [create an account](https://account.windowsazure.com/Home/Index).

- **Event Hubs namespace with an Event Hub:** To interact with Azure Event Hubs, you'll also need to have a namespace and Event Hub available.  If you are not familiar with creating Azure resources, you may wish to follow the step-by-step guide for [creating an Event Hub using the Azure portal](https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-create).  There, you can also find detailed instructions for using the Azure CLI, Azure PowerShell, or Azure Resource Manager (ARM) templates to create an Event Hub.

- **Azure Storage account with blob storage:** To persist checkpoints as blobs in Azure Storage, you'll need to have an Azure Storage account with blobs available.  If you are not familiar with Azure Storage accounts, you may wish to follow the step-by-step guide for [creating a storage account using the Azure portal](https://docs.microsoft.com/en-us/azure/storage/common/storage-quickstart-create-account?toc=%2Fazure%2Fstorage%2Fblobs%2Ftoc.json&tabs=azure-portal).  There, you can also find detailed instructions for using the Azure CLI, Azure PowerShell, or Azure Resource Manager (ARM) templates to create storage accounts.

- **C# 8.0:** The Azure Event Hubs client library makes use of new features that were introduced in C# 8.0.  You can still use the library with older versions of C#, but some of its functionality won't be available.  In order to enable these features, you need to [target .NET Core 3.0](https://docs.microsoft.com/en-us/dotnet/standard/frameworks#how-to-specify-target-frameworks) or [specify the language version](https://docs.microsoft.com/en-gb/dotnet/csharp/language-reference/configure-language-version#override-a-default) you want to use (8.0 or above).  If you are using Visual Studio, versions prior to Visual Studio 2019 are not compatible with the tools needed to build C# 8.0 projects.  Visual Studio 2019, including the free Community edition, can be downloaded [here](https://visualstudio.microsoft.com/vs/).

  **Important Note:** The use of C# 8.0 is mandatory to run the [examples](#examples) and the [samples](#next-steps) without modification.  You can still run the samples if you decide to tweak them.

To quickly create the needed resources in Azure and to receive connection strings for them, you can deploy our sample template by clicking:  

[![](http://azuredeploy.net/deploybutton.png)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FAzure%2Fazure-sdk-for-net%2Fmaster%2Fsdk%2Feventhub%2FAzure.Messaging.EventHubs.Processor%2Fassets%2Fsamples-azure-deploy.json)

### Install the package

Install the Azure Event Hubs Event Processor client library for .NET using [NuGet](https://www.nuget.org/):

```PowerShell
Install-Package Azure.Messaging.EventHubs.Processor -Version 5.0.0-preview.6
```

### Obtain an Event Hubs connection string

For the event processor client to interact with an Event Hub, it will need to understand how to connect and authorize with it.  The easiest means for doing so is to use a connection string, which is created automatically when creating an Event Hubs namespace.  If you aren't familiar with shared access policies in Azure, you may wish to follow the step-by-step guide to [get an Event Hubs connection string](https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-get-connection-string).

### Obtain an Azure Storage connection string

For the event processor client to make use of Azure Storage blobs, it will need to understand how to connect to a storage account and authorize with it.  The most straightforward method of doing so is to use a connection string, which is generated at the time that the storage account is created.  If you aren't familiar with storage accounts in Azure, you may wish to follow the step-by-step guide to [configure Azure Storage connection strings](https://docs.microsoft.com/en-us/azure/storage/common/storage-configure-connection-string).

## Key concepts

- An **event processor** is a construct intended to manage the responsibilities associated with connecting to a given Event Hub and processing events from each of its partitions, in the context of a specific consumer group.  The act of processing events read from the partition and handling any errors that occur is delegated by the event processor to code that you provide, allowing your logic to concentrate on delivering business value while the processor handles the tasks associated with reading events, managing the partitions, and allowing state to be persisted in the form of checkpoints. 

- **Checkpointing** is a process by which readers mark and persist their position for events that have been processed for a partition. Checkpointing is the responsibility of the consumer and occurs on a per-partition, typically in the context of a specific consumer group.  For the `EventProcessorClient`, this means that, for a consumer group and partition combination, the processor must keep track of its current position in the event stream.  

  When an event processor connects, it will begin reading events at the checkpoint that was previously persisted by the last processor of that partition in that consumer group, if one exists.  As an event processor reads and acts on events in the partition, it should periodically create checkpoints to both mark the events as "complete" by downstream applications and to provide resiliency should an event processor or the environment hosting it fail.  Should it be necessary, it is possible to reprocess events that were previously marked as "complete" by specifying an earlier offset through this checkpointing process.

- A **partition** is an ordered sequence of events that is held in an Event Hub. Partitions are a means of data organization associated with the parallelism required by event consumers.  Azure Event Hubs provides message streaming through a partitioned consumer pattern in which each consumer only reads a specific subset, or partition, of the message stream. As newer events arrive, they are added to the end of this sequence. The number of partitions is specified at the time an Event Hub is created and cannot be changed.

- A **consumer group** is a view of an entire Event Hub. Consumer groups enable multiple consuming applications to each have a separate view of the event stream, and to read the stream independently at their own pace and from their own position.  There can be at most 5 concurrent readers on a partition per consumer group; however it is recommended that there is only one active consumer for a given partition and consumer group pairing. Each active reader receives all of the events from its partition; if there are multiple readers on the same partition, then they will receive duplicate events.

For more concepts and deeper discussion, see: [Event Hubs Features](https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-features).

## Examples

### Creating an Event Processor Client

Since the `EventProcessorClient` as a dependency on Azure Storage blobs for persistence of its state, you'll need to provide a `BlobContainerClient` for the processor, which has been configured for the storage account and container that should be used.

```csharp
string storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
string blobContainerName = "<< NAME OF THE BLOBS CONTAINER >>";

string eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
string eventHubName = "<< NAME OF THE EVENT HUB >>";
string consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

BlobContainerClient storageClient = new BlobContainerClient(storageConnectionString, blobContainerName);

EventProcessorClient processor = new EventProcessorClient
(
    storageClient,
    consumerGroup,
    eventHubsConnectionString,
    eventHubName
);
```

### Configure the Event and Error Handlers

In order to use the `EventProcessorClient`, handlers for event processing and errors must be provided.  These handlers are considered self-contained and developers are responsible for ensuring that exceptions within the handler code are accounted for.

```csharp
var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
var blobContainerName = "<< NAME OF THE BLOBS CONTAINER >>";
var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

async Task processEventHandler(ProcessEventArgs eventArgs)
{
    try
    {
        // Perform the application-specific processing for an event
        await DoSomethingWithTheEvent(eventArgs.Partition, eventArgs.Data);
    }
    catch
    {
        // Handle the exception from handler code
    }
}

async Task processErrorHandler(ProcessErrorEventArgs eventArgs)
{
    try
    {
        // Perform the application-specific processing for an error
        await DoSomethingWithTheError(eventArgs.Exception);
    }
    catch
    {
        // Handle the exception from handler code
    }   
}

var storageClient = new BlobContainerClient(storageConnectionString, blobContainerName);
var processor = new EventProcessorClient(storageClient, consumerGroup, eventHubsConnectionString, eventHubName);

processor.ProcessEventAsync += processEventHandler;
processor.ProcessErrorAsync += processErrorHandler;
```

### Start and Stop Procesing

The `EventProcessorClient` will perform its processing in the background once it has been explicitly started and continue doing so until it has been explicitly stopped.  While this allows the application code to perform other tasks, it also places the responsibility of ensuring that the process does not terminate during processing if there are no other tasks being performed.

```csharp
private async Task ProcessUntilCanceled(CancellationToken cancellationToken)
{
    var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
    var blobContainerName = "<< NAME OF THE BLOBS CONTAINER >>";
    var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
    var eventHubName = "<< NAME OF THE EVENT HUB >>";
    var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

    Task processEventHandler(ProcessEventArgs eventArgs) => Task.CompletedTask;
    Task processErrorHandler(ProcessErrorEventArgs eventArgs) => Task.CompletedTask;

    var storageClient = new BlobContainerClient(storageConnectionString, blobContainerName);
    var processor = new EventProcessorClient(storageClient, consumerGroup, eventHubsConnectionString, eventHubName);

    processor.ProcessEventAsync += processEventHandler;
    processor.ProcessErrorAsync += processErrorHandler;
    
    await processor.StartProcessingAsync();
    
    try
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
        }
        
        await processor.StopProcessingAsync();
    }
    finally
    {
        // To prevent leaks, the handlers should be removed when processing is complete
        processor.ProcessEventAsync -= processEventHandler;
        processor.ProcessErrorAsync -= processErrorHandler;
    }
}
```

## Troubleshooting

### Common exceptions

#### Timeout

This indicates that the Event Hubs service did not respond to an operation within the expected amount of time.  This may have been caused by a transient network issue or service problem.  The Event Hubs service may or may not have successfully completed the request; the status is not known.  It is recommended to attempt to verify the current state and retry if necessary.

#### Quota Exceeded

This typically indicates that there are too many active event processors for a consumer group.  This limit depends on the tier of the Event Hubs namespace, and moving to a higher tier may be desired.  An alternative would be do create additional consumer groups and ensure that the number of active processors for any group is within the limit.  Please see [Azure Event Hubs quotas and limits](https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-quotas) for more information.

### Other exceptions

For detailed information about these and other exceptions that may occur, please refer to [Event Hubs messaging exceptions](https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-messaging-exceptions). 

## Next steps

Beyond the scenarios discussed, the Azure Event Hubs Event Prcessor library offers support for additional scenarios to help take advantage of the full feature set of the `EventProcessorClient`.  In order to help explore some of these scenarios, the library offers a [project of samples](./samples) to serve as an illustration for common scenarios.

The samples are accompanied by a console application which you can use to execute and debug them interactively.  The simplest way to begin is to launch the project for debugging in Visual Studio or your preferred IDE and provide the Event Hubs connection information in response to the prompts.  

Each of the samples is self-contained and focused on illustrating one specific scenario.  Each is numbered, with the lower numbers concentrating on basic scenarios and building to more complex scenarios as they increase; though each sample is independent, it will assume an understanding of the content discussed in earlier samples.

The available samples are:

- [Hello world](./samples/Sample01_HelloWorld.cs)  
  An introduction to the Event Processor client, illustrating how to create the client and perform basic operations.

- [Create an Event Processor client with custom options](./samples/Sample02_ProcessorWithCustomOptions.cs)  
  An introduction to the Event Processor client, exploring additional options for creating the processor.

- [Perform basic event processing](./samples/Sample03_BasicEventProcessing.cs)  
  An introduction to the Event Processor client, illustrating how to perform basic event processing.

- [Create checkpoints while processing](./samples/Sample04_BasicCheckpointing.cs)  
  An introduction to the Event Processor client, illustrating how to create simple checkpoints.

## Contributing  

This project welcomes contributions and suggestions.  Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

Please see our [contributing guide](./../Azure.Messaging.EventHubs/CONTRIBUTING.md) for more information.
  
![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Feventhub%2FAzure.Messaging.EventHubs.Processor%2FREADME.png)