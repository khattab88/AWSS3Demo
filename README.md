# AWSS3Demo

Upload files to AWS S3 on .Net 6 Web API

## Steps:
1. Create AWS account [AWS Signup](https://portal.aws.amazon.com/billing/signup?nc2=h_ct&src=header_signup&refid=aab93946-116c-44e8-94f5-49181e2867fd&redirect_url=https%3A%2F%2Faws.amazon.com%2Fregistration-confirmation#/start/email)
2. Create IAM user & assign user to "AdministratorAccess" Policy (or add user to user group with same policy) 
3. copy user's AccessKey and SecretAccessKey values
4. (Optional) install AWS CLI [AWS CLI](https://docs.aws.amazon.com/cli/latest/userguide/getting-started-install.html)
5. (Optional) configure AWS CLI [Configure AWS CLI](https://docs.aws.amazon.com/cli/latest/userguide/cli-authentication-user.html#cli-authentication-user-configure.title)
6. create s3 bucket with unique name (ex: demo-aws-s3-test)
7. (Optional) test using AWS CLI:
 
   => list all s3 buckets `aws s3 ls`

   => list all files in bucket `aws s3api list-objects --bucket BUCKET_NAME`


Reference: https://www.youtube.com/watch?v=6lRdUcbRZ0w&ab_channel=MohamadLawand 
