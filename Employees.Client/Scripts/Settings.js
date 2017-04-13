var Settings =
    {
        API: {
            Domain: "http://localhost:50243/",
            Employees: {
                GetList: function () { return Settings.API.Domain + "api/Employees/"; },
                Create: function () { return Settings.API.Domain + "api/Employees/"; },
                Delete: function (id) { return Settings.API.Domain + "api/Employees/" + id; }
            },
            Jobs: {
                GetList: function () { return Settings.API.Domain + "api/Jobs"; }
            }
        }
    }