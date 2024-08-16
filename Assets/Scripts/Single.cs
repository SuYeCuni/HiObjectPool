using System;

    public class Single<T>
        where T: class
    {
        private static T _instance;

        // 没有实例时创建一个实例，有的话返回创造过的那个实例
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    Type type = typeof(T);
                    _instance = Activator.CreateInstance(type, true) as T;
                }

                return _instance;
            }
        }
        protected Single(){}
    }

