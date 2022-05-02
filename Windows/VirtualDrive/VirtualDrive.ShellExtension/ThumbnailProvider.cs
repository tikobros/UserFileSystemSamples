using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ITHit.FileSystem.Samples.Common.Windows.ShellExtension.Thumbnails;
using ITHit.FileSystem.Samples.Common.Windows.Rpc;
using ITHit.FileSystem.Samples.Common.Windows.Rpc.Generated;
using ITHit.FileSystem.Samples.Common.Windows.ShellExtension;

namespace VirtualDrive.ShellExtension
{
    /// <summary>
    /// Thumbnails provider Windows Shell Extension.
    /// </summary>
    [ComVisible(true)]
    [ProgId("VirtualDrive.ThumbnailProvider")]
    [Guid("05CF065E-E135-4B2B-9D4D-CFB3FBAC73A4")]
    public class ThumbnailProvider : ThumbnailProviderBase
    {
        public override async Task<byte[]> GetThumbnailsAsync(string filePath, uint size)
        {
            try
            {
                GrpcClient grpcClient = new GrpcClient(ShellExtensionConfiguration.AppSettings.RpcCommunicationChannelName);
                ThumbnailRequest thumbnailRequest = new ThumbnailRequest();
                thumbnailRequest.Path = filePath;
                thumbnailRequest.Size = size;

                Thumbnail thumbnail = await grpcClient.RpcClient.GetThumbnailAsync(thumbnailRequest);

                return thumbnail.Image.ToByteArray();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}
