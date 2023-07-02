using System.Reflection;

namespace Utils
{
    public class TasksPicker
    {
        private Random _rnd = new Random((int)DateTime.Now.Ticks);
        private string _assemblyFolder;

        public TasksPicker(string assemblyFolder)
        {
            _assemblyFolder = assemblyFolder;
        }

        public TasksPicker(object root)
        {
            var assembly = root.GetType().Assembly;
            _assemblyFolder = Path.GetDirectoryName(assembly.Location);
        }

        public string[] Get(int n)
        {
            var assemblies = GetAssemblies();
            var tasks = assemblies.Select(x => GetTypesForRepetition(x)).SelectMany(x => x).Select(x => x.FullName).ToArray();
            var indexes = RandomIndexes(tasks.Length, n);
            var res = indexes.Select(x => tasks[x]).ToArray();
            return res;
        }

        private IEnumerable<Type> GetTypesForRepetition(Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetCustomAttributes(typeof(ShouldRepeatAttribute), true).Length > 0)
                {
                    yield return type;
                }
            }
        }

        private int[] RandomIndexes(int bound, int count)
        {
            var cnt = Math.Min(bound, count);
            var set = new HashSet<int>(cnt);

            while (set.Count < cnt)
            {
                var i = _rnd.Next(0, bound);
                set.Add(i);
            }
            return set.ToArray();
        }

        private IEnumerable<Assembly> GetAssemblies()
        {
            // return AppDomain.CurrentDomain.GetAssemblies();

            List<Assembly> assemblies = new List<Assembly>();
            foreach (var path in Directory.GetFiles(_assemblyFolder, "*.dll"))
            {
                assemblies.Add(Assembly.LoadFrom(path));
            }
            return assemblies;
        }
    }
}
