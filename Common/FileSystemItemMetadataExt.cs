using ITHit.FileSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ITHit.FileSystem.Samples.Common
{
    /// <summary>
    /// Represents a basic information about the file or the folder in the user file system.
    /// In addition to properties provided by <see cref="IFileSystemItem"/> this class contains Etag property.
    /// </summary>
    public class FileSystemItemMetadataExt : IFileSystemItemMetadata
    {
        /// <inheritdoc/>
        public byte[] ItemId { get; set; }

        ///<inheritdoc/>
        public string Name { get; set; }

        ///<inheritdoc/>
        public FileAttributes Attributes { get; set; }

        ///<inheritdoc/>
        public byte[] CustomData { get; set; } = new byte[] { };

        ///<inheritdoc/>
        public DateTimeOffset CreationTime { get; set; }

        ///<inheritdoc/>
        public DateTimeOffset LastWriteTime { get; set; }

        ///<inheritdoc/>
        public DateTimeOffset LastAccessTime { get; set; }

        ///<inheritdoc/>
        public DateTimeOffset ChangeTime { get; set; }

        /// <summary>
        /// Server ETag.
        /// </summary>
        public string ETag { get; set; }

        /// <summary>
        /// Indicates if the item is locked in the remote storage.
        /// </summary>
        public bool IsLocked { get; set; } = false;

        /// <summary>
        /// Custom columns data to be displayed in the file manager.
        /// </summary>
        public IEnumerable<FileSystemItemPropertyData> CustomProperties { get; set; } = new FileSystemItemPropertyData[] { };
    }
}
