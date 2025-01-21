using System;

namespace GymManagement.Application.Common.Interface;

public interface IUnitOfWork
{
    Task CommitChangesAsync();
}
