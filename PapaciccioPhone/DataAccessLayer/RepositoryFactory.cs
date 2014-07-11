using PapaciccioPhone.DataAccessLayer.Implementations;
using PapaciccioPhone.DataAccessLayer.Interfaces;

namespace PapaciccioPhone.DataAccessLayer
{
    public static class RepositoryFactory
    {
        private static ICommandRepository _commandRepository;
        public static ICommandRepository CommandRepository
        {
            get { return _commandRepository ?? (_commandRepository = new HttpCommandRepository()); }
        }
        
    }
}
