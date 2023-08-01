using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningKafka.Infra.Configs
{
    public class MongoConfigurationFluent
    {
        public static MongoConfiguration Configure()
        {
            return new MongoConfiguration();
        }
    }
}
