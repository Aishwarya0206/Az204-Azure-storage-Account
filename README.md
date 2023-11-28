# Az204-Azure-storage-Account
.NET program for blob, queue &amp; table

**Blob lease** => Used in audits, where two or more application access the same blobs.

**Block Blob operations**
  1. Creating a container
  2. Uploading a blob
  3. Downloading a blob
  4. List the blobs
  5. Deleting the container

**Queue Operations**
**_Use case_**: If two or more videos are uploaded into youtube and stored in a database (unprocessed data/videos), from where again the youtube processes the video for verifying the originality of the video and storing it in a database again(processed data/ video). Instead of fetching the video from database we can send messages in queue with video_id and status of it. When the message is delivered to the instance of the processing app, it can process the video by fetching the required video with a valid video_id and status. Once, it is processed then it can be de-queued.
  1. Inserting a message (Queue)
  2. Retrieving a message (De-queue)

**Table Operations**
  1. Creating entities (Adding the rows)
  2. Querying the entities (Fetching the required rows from a particular partition)
  3. Deleting an entity
