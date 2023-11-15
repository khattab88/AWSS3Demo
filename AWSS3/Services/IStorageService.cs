using AWSS3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSS3.Services
{
    public interface IStorageService
    {
        Task<S3ResponseDto> uploadFileAsync(S3Object s3Object, AwsCredentials awsCredentials);
    }
}
