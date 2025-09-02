using MediatR;

namespace SimpleBookKeepingMobile.CommandAndQueries.Clear
{
    public class ClearDatabaseCommand : IRequest<bool>
    {
    }
}