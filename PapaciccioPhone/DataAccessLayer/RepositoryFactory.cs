#if DEBUG
using PapaciccioPhone.DataAccessLayer.Implementations.Mock;
#else
using PapaciccioPhone.DataAccessLayer.Implementations.Http;
#endif
using PapaciccioPhone.DataAccessLayer.Interfaces;

namespace PapaciccioPhone.DataAccessLayer
{
    public static class RepositoryFactory
    {
        private static ICommandRepository _commandRepository;
        public static ICommandRepository CommandRepository
        {
#if DEBUG
            get { return _commandRepository ?? (_commandRepository = new MockCommandRepository()); }
#else
            get { return _commandRepository ?? (_commandRepository = new HttpCommandRepository()); }
#endif
        }

        private static ICommandDataRepository _commandDataRepository;
        public static ICommandDataRepository CommandDataRepository
        {
#if DEBUG
            get { return _commandDataRepository ?? (_commandDataRepository = new MockCommandDataRepository()); }
#else
            get { return _commandDataRepository ?? (_commandDataRepository = new HttpCommandDataRepository()); }
#endif
        }
    }
}
