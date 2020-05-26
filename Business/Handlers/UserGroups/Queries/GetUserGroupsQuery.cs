﻿using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.UserGroups.Queries
{
    public class GetUserGroupsQuery : IRequest<IDataResult<IEnumerable<UserGroup>>>
    {
        public class GetUserGroupsQueryHandler : IRequestHandler<GetUserGroupsQuery, IDataResult<IEnumerable<UserGroup>>>
        {
            private readonly IUserGroupRepository _userGroupDal;

            public GetUserGroupsQueryHandler(IUserGroupRepository userGroupDal)
            {
                _userGroupDal = userGroupDal;
            }

            public async Task<IDataResult<IEnumerable<UserGroup>>> Handle(GetUserGroupsQuery request, CancellationToken cancellationToken)
            {
                return new SuccessDataResult<IEnumerable<UserGroup>>(await _userGroupDal.GetListAsync());
            }
        }
    }
}
