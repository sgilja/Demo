using Core.Entities;
using Core.Interfaces;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Folders
{
    public class FileSearchSpecification : ISpecification<FolderFile>
    {
        private readonly int? _folderId;
        private readonly string _name;

        public FileSearchSpecification(int? folderId, string name)
        {
            _folderId = folderId;
            _name = name;
        }

        public Expression<Func<FolderFile, bool>> Predicate
        {
            get
            {
                var predicate = PredicateBuilder.New<FolderFile>();

                if (_folderId.HasValue) {
                    predicate = predicate.And(p => p.FolderId == _folderId.Value);
                }

                if (_name != null) {
                    predicate = predicate.And(p => p.Name.ToLower().StartsWith(_name.ToLower()));
                }

                return predicate;
            }
        }
    }
}
