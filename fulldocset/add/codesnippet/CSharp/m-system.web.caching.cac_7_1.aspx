            // Make key1 dependent on several files.
            String[] files = new String[2];
            files[0] = Server.MapPath("isbn.xml");
            files[1] = Server.MapPath("customer.xml");
            CacheDependency dependency = new CacheDependency(files);

            Cache.Insert("key1", "Value 1", dependency);
        }