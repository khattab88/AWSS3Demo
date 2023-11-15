using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Transfer;
using AWSS3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSS3.Services
{
    public class StorageService : IStorageService
    {
        public async Task<S3ResponseDto> uploadFileAsync(S3Object s3Object, AwsCredentials awsCredentials)
        {
            var credentials = new BasicAWSCredentials(awsCredentials.AwsKey, awsCredentials.AwsSecretKey);

            var config = new AmazonS3Config()
            {
                RegionEndpoint = Amazon.RegionEndpoint.EUNorth1
            };

            var resposne = new S3ResponseDto();

            try
            {
                var uploadRequest = new TransferUtilityUploadRequest()
                {
                    InputStream = s3Object.InputStream,
                    Key = s3Object.Name,
                    BucketName = s3Object.BucketName,
                    CannedACL = S3CannedACL.NoACL
                };

                using var client = new AmazonS3Client(credentials, config);

                var transferUtility = new TransferUtility(client);

                await transferUtility.UploadAsync(uploadRequest);

                resposne.StatusCode = 200;
                resposne.Message = $"file: {s3Object.Name} has been uploaded successfully";
            }
            catch (AmazonS3Exception ex) 
            {
                resposne.StatusCode = (int)ex.StatusCode;
                resposne.Message = ex.Message;
            }
            catch (Exception ex)
            {
                resposne.StatusCode = 500;
                resposne.Message = ex.Message;
            }

            return resposne;
        }
    }
}
