# Release History

## 5.0.0-preview.6

### Acknowledgements

Thank you to our developer community members who helped to make the Event Hubs client libraries better with their contributions to this release:

- Alberto De Natale _([GitHub](https://github.com/albertodenatale))_

### Changes

#### Bug fixes and foundation improvements

- A bug with the use of Azure.Identity credential scopes has been fixed; Azure identities should now allow for proper authorization with Event Hubs resources.   
_(A community contribution, courtesy of [albertodenatale](https://github.com/albertodenatale))_

- A bug with the renewal of connection string-based credentials has been fixed; clients using a connection string will now properly refresh when necessary instead of experiencing an error.

- Some performance tuning has been done, focusing on reducing allocations associated with frequently used types where possible.

#### Consuming events

- The `EventHubsConsumerClient` is no longer bound to a partition, an owner level, or tracking of last enqueued event properties; these attributes may be specified when requesting to read events, allowing more granular control over behavior without the need to create multiple clients.

- Events may now be read across all partitions of an Event Hub using the `ReadEvents` method of the consumer client.  This is intened for exploring Event Hubs and not recommended for production use; for production scenarios, please consider using the `EventProcessorClient` as a more robust alternative.

- Events read using the consumer client are now accompanied by a `PartitionContext` helping to identify the source partition for an event and allowing for partition-specific operations, such as reading the last enqueued event properties for that partition.

#### Publishing events

- The `EventHubsProducerClient` client is no longer bound to a partition for sending events to a specific partition.  It will now accept a partition identifier as part of the options when creating an event batch.  This option may not be used with a partition key in the same batch; only one or the other may be specified.  This allows for more flexibility when publishing events without the need to create multiple clients.

#### Authorization

- Test and sample infrastructure has been updated to work with Azure.Identity credentials in addition to connection strings.  
_(A community contribution, courtesy of [albertodenatale](https://github.com/albertodenatale))_
  
- A sample demonstrating the use of an Azure Active Identity principal with Event Hubs is now available.  
_(A community contribution, courtesy of [albertodenatale](https://github.com/albertodenatale))_

- The `EventHubsSharedKeyCredential` has been removed from this release for further design and improvements; it is intended to be reintroduced in the future.

#### Organization and naming

- A large portion of the public API surface, including members and parameters, have had adjustments to their naming in order to improve discoverability, provide better context to developers, and better conform to the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html).

- The `EventProcessorClient` has been moved into its own [package](./../Azure.Messaging.EventHubs.Processor) and evolved into an opinionated implementation on top of Azure Storage Blobs.  This is intended to offer a more streamlined developer experience for the majority of scenarios and allow developers to more easily take advantage of the processor.

- A collection of internal supporting types were moved into a new [shared library](./../Azure.Messaging.EventHubs.Shared) to allow them to be shared as source between the Event Hubs client libraries.  The tests assoociated with these types were also moved to the shared library for locality with the source being tested.

## 5.0.0-preview.5 

### Acknowledgments 

Thank you to our developer community members who helped to make the Azure SDKs better with their contributions to this release:

- Alberto De Natale _([GitHub](https://github.com/albertodenatale))_

### Changes

#### Organization and naming

- The early stages of a large refactoring of the Event Hub client type hierarchy is complete;  Event Hub producers and consumers are now stand-alone clients that can be created independently, and which may or may not share a connection to the Event Hubs service at the discretion of the developer.    

  **_Please Note:_** These changes are part of a larger effort that is currently in process.  The client types have not yet been refactored to remove affinity to a specific partition which leaves some operations feeling somewhat awkward with the new structure.
  
#### Bug fixes and foundation improvements

- Client types using Azure identity for authorization should now be working properly; a bug was fixed to allow the proper authorization scopes to be requested.  
  _(A community contribution, courtesy of [albertodenatale](https://github.com/albertodenatale))_
  
- Service communication is now being performed by an internal communication stack; previously, it had been delegated to an internal copy of the legacy client library.

- Cancellation tokens are now supported throughout the client hierarchy and across operations.

- Telemetry is now emitting a `User-Agent` member, which is standard across other client libraries in the Azure SDK.

- With the new hierarchy allowing clients to be more self-contained, the configuration of retry policies and timeouts have been made more consistent and easier to reason about.  Each may be configured as part of the options for a client and will retain either the value provided by developers or the default.  There is no longer a notion of inherited values from a "parent" client.

#### Consuming events

- The body of an `EventData` instance is now available as a stream, for convenience.

- The information about the last event enqueued to an Event Hub partition is now presented on-demand as an immutable object, if the tracking option was enabled.  This ensures that the properties are stable and consistent when being read, rather than being subject to in-place updates each time a new event is received.

## 5.0.0-preview.4

### Changes

#### Event Processor

- Included the Event Hubs fully qualified namespace as part of the checkpoint information, ensuring that there is no conflict between Event Hubs instances in different regions using the same Event Hub and consumer group names.

- Distributed tracing support has been added to the Event Processor.

#### Bug fixes and foundation improvements

- Fixed date parsing for time zones ahead of UTC in the Event Hub Consumer when tracking of the last event was disabled.

- Updated dependencies to take advantage of newer client libraries for identity management, blob storage, and .NET Core improvements.

- Improved stability and performance with refactorings around hot paths and areas of technical debt.

## 5.0.0-preview.3

### Changes

#### Consuming Events

- The full set of system properties was reintroduced to the `EventData` for events received from the service.  In addition to the well-known properties for identifying an event's place in the partition (`Offset`, `SequenceNumber`, and `EnqueuedTime`), any additional metadata sent as part of an event will appear in the `SystemProperties` dictionary.

- The `EventHubConsumer` can be configured to track information about the last event to be enqueued into its associated partition in order to allow for monitoring the backlog of events to be processed without the need to make explicit calls to request partition properties from the `EventHubClient`.

- Consuming events using `SubscribeToEvents` has been refactored for better performance and lower resource use. 

#### Event Processor

- Creation of an `EventProcessor` has been refined with the goal of allowing simpler use for standard scenarios while maintaining flexibility for complex ones.  The `EventProcessor` is now able to manage partition processor instances for implementations with a default constructor.

- The `EventProcessor` will now coordinate with other active `EventProcessor` instances for a given Event Hub and consumer group in order to share partitions and ensure that processing work is balanced between them.  `EventProcessor` instances may be activated or deactivated independently and the remaining processors will redistribute partitions as needed.

- The interface for processing partitions has been changed to a base class, in order to allow developers to make the decision which of the available methods they would like to override, rather than being forced to implement each one.

#### General

- The client library for Event Hubs is now emitting diagnostics information for distributed tracing.  _(see: [proposal](https://github.com/w3c/trace-context-amqp/blob/411fdeabea45d36db827b7097235549b30fac8e8/spec/20-AMQP_FORMAT.md))_

- Some public types were scoped in a way that made them difficult to mock for library consumers.  These have been re-scoped to `protected internal` for better testability.  `EventData` and metadata types were the significant instances.

## 5.0.0-preview.2

### Changes

#### General

- Public members of type `DateTime` were converted to `DateTimeOffset` to explicitly represent that they are UTC

- Members of type `DateTimeOffset` have had the `Utc` suffix removed from their names, as the `DateTimeOffset` type removes ambiguity about the time zone

- Members representing a partition offset that were incorrectly exposed as `string` have been converted to `int` to provide a unified type.

- Renamed all instances of `EventHubPath` to `EventHubName` to align with the usage context and unify on the chosen semantics across the client library for different languages.

- Ongoing minor tweaks to formatting, wording, and spelling of documentation and XML document comments.

#### Publishing events

- Reintroduced the `EventDataBatch`, allowing for publication of a batch of events with known size constraint.  This is intended to ensure that publishers can build batches without the potential for an error when sending and to allow publishers with bandwidth concerns to control the size of each batch published.

- Enhanced the `EventHubProducer` to allow creation of an `EventDataBatch` and to accept them for publication.

#### Consuming events

- Added a means to subscribe to the events exposed by an `EventHubConsumer` in the form of an asynchronous iterator.   Using the iterator, consumers are able to use the familiar `foreach` pattern to enumerate events as they are available and process them.  Optionally, consumers may specify a maximum time to wait for events to arrive which, when exceeded, will emit a null event if none were available, returning control to the loop and allowing cancellation or other processing needs.

- Introduced the initial concept of a new version of the `EventProcessor`, intended as a neutral framework for processing events across all partitions for a given Event Hub and in the context of a specific Consumer Group.  This early preview is intended to allow consumers to test the new design using a single instance that does not persist checkpoints to any durable store.

#### Exceptions

- Created an exception hierarchy that incorporates the exceptions exposed by the legacy client library, covering the same set of scenarios with minor changes to naming to better clarify the context.

- Ensured that custom Event Hubs exceptions are properly translated to the new versions, no longer exposing legacy exception types.

#### Retries and timeouts

- Removed the exposed retry policies in favor of a set of retry options based on the options found in `Azure.Core` in order to keep the API familiar.

- An abstract `EventHubsRetryPolicy` has been created to serve as the contract for custom retry policy implementations.

- An option for fixed retry has been added to accompany the exponential retry that was in place previously.
Operation timeouts have been moved from the associated client options and incorporated into the retry options and retry policies.

## 5.0.0-preview.1

Version 5.0.0-preview.1 is a preview of our efforts in creating a client library that is developer-friendly, idiomatic to the .NET ecosystem, and as consistent across different languages and platforms as possible.  The principles that guide our efforts can be found in the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html).

For more information, please visit: [https://aka.ms/azure-sdk-preview1-net](https://aka.ms/azure-sdk-preview1-net).