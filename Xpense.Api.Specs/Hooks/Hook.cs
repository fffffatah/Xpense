using System;
using TechTalk.SpecFlow;
using Xpense.Data.Core.Database;
using Xpense.Data.Core.Repository;

namespace Xpense.Api.Specs.Hooks
{
    [Binding]
    public class Hooks
    {
        
    }
    // public class Hooks<TEntity> where TEntity : class
    // {
    //     private readonly IRepository<TEntity> _repository;
    //     private readonly List<TEntity> _entitiesToRemove;
    //
    //     public Hooks(IRepository<TEntity> repository)
    //     {
    //         _repository = repository;
    //         _entitiesToRemove = new List<TEntity>();
    //     }
    //
    //     [AfterScenario]
    //     public void AfterScenario()
    //     {
    //         // Remove the entities added during the test
    //         _repository.DeleteRangeAsync(_entitiesToRemove);
    //     }
    //
    //     // You can add a method to track the entities added during the test
    //     public void TrackEntity(TEntity entity)
    //     {
    //         _entitiesToRemove.Add(entity);
    //     }
    // }
}