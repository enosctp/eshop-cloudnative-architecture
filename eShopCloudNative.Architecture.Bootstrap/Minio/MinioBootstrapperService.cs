﻿using eShopCloudNative.Architecture.Bootstrap;
using Microsoft.Extensions.Configuration;
using Minio;
using Minio.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShopCloudNative.Architecture.Extensions;
using System.Diagnostics.CodeAnalysis;

namespace eShopCloudNative.Architecture.Minio;
public class MinioBootstrapperService : IBootstrapperService
{
    public List<MinioBucket> BucketsToCreate { get; set; }

    public IConfiguration Configuration { get; set; }

    public IMinioClientAdapter Minio { get; set; }

    public virtual Task InitializeAsync()
    {
        if (this.Configuration.GetValue<bool>("boostrap:minio"))
        {
            
        }
        else
        {
            //TODO: Logar dizendo que está ignorando
        }

        return Task.CompletedTask;
    }

    public virtual async Task ExecuteAsync()
    {
        if (this.Configuration.GetValue<bool>("boostrap:minio"))
        {
            List<Bucket> oldBuckets  = (await this.Minio.ListBucketsAsync()).Buckets;

            foreach (var bucket in this.BucketsToCreate)
            {
                if (oldBuckets.Any(it => it.Name == bucket.BucketName) == false)
                {
                    await this.Minio.MakeBucketAsync(new MakeBucketArgs().WithBucket(bucket.BucketName));

                    if (bucket.Policy != null)
                        await this.Minio.SetPolicyAsync(new SetPolicyArgs().WithBucket(bucket.BucketName).WithPolicy(bucket.Policy.GetJsonPolicy()));

                }
            }
        }
        else
        {
            //TODO: Logar dizendo que está ignorando
        }
    }

}
