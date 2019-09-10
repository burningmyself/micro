using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unite
{
    public static class ObjectHelper
    {
        public static T CopyTo<T>(this object obj, T hava_obj)
        {
            hava_obj.GetType().GetProperties().ToList().ForEach(r => {
                
                    obj.GetType().GetProperties().ToList().ForEach(v =>
                    {
                        if (r.Name != "Id")
                        {
                            if (r.Name == v.Name)
                            {
                                r.SetValue(hava_obj, v.GetValue(obj), null);
                            }
                        }
                    });
            });
            return hava_obj;
        }

        public static T SetTo<T>(this T obj, string name, string value) where T : class
        {
            obj.GetType().GetProperties().ToList().ForEach(r => {
                if (r.Name == name)
                    r.SetValue(obj, value);
            });
            return obj;
        }
    }
}
