﻿using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System;

namespace TaskoMask.BuildingBlocks.Infrastructure.MongoDB
{
    /// <summary>
    /// 
    /// </summary>
    public static class MongoDbExtensions
    {

        /// <summary>
        /// Drop database
        /// </summary>
        public static void DropDatabase<TContext>(IServiceProvider serviceProvider) where TContext : MongoDbContext
        {
            using var serviceScope = serviceProvider.CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetService<TContext>();

            dbContext.DropDatabase();
        }



        /// <summary>
        /// 
        /// </summary>
        public static bool Has<TModel>(this IList<string> collections, string name = "")
        {
            var collection = name;
            if (string.IsNullOrEmpty(collection))
            {
                collection = typeof(TModel).Name;

                if (!collection.EndsWith("s")) collection += "s";
            }

            return collections.Contains(collection);
        }


    }
}
