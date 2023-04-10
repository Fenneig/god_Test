using System.Collections.Generic;
using System.Linq;
using GoTTest.Services;
using UnityEngine;

namespace GoTTest.Model.Definitions.Repositories
{
    public class DefRepository<TDefType> : ScriptableObject where TDefType : IHaveId
    {
        [SerializeField] protected TDefType[] _collection;

        public TDefType Get(string id) =>
            _collection.FirstOrDefault(x => x.Id == id);

        public TDefType[] GetAll =>
            new List<TDefType>(_collection).ToArray();
    }
}