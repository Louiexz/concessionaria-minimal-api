using API.Services;

namespace API.Controller {
    public class CarController {
        protected dynamic concessionaria = new ConcessionariaManager();

        public CarController(WebApplication app, dynamic userSession)
        {
            app.MapGet
            (
                "/vehicle/get/all",
                () => {
                    if (userSession.IsLogged) {
                        var vehicles = concessionaria.GetVehicles();
                        var vehiclesList = "";
                        foreach (var vehicle in vehicles) {
                            vehiclesList += vehicle.ToString() + ", ";        
                        }

                        return Results.Ok(vehiclesList);    
                    } else {
                        return Results.BadRequest("Authentication needed.");
                    }                    
                }
            ).WithTags("Vehicle");

            app.MapGet
            (
                "/vehicle/get/:id",
                (int id) =>
                {
                    if (userSession.IsLogged) {
                        if (id >= 0) {
                            try {
                                var vehicle = concessionaria.GetVehicle(id);
                                return Results.Ok
                                (
                                    $"\nType: {vehicle.GetVehicleType()}" +
                                    $"\nMark: {vehicle.GetMark()}" +
                                    $"\nModel: {vehicle.GetModel()}" +
                                    $"\nYear: {vehicle.GetYear()}"
                                );
                            } catch (Exception) {
                                return Results.BadRequest("Vehicle id doesn't exist");     
                            }
                        } else {
                            return Results.BadRequest("Invalid input.");
                        }
                    } else {
                        return Results.BadRequest("Authentication needed.");
                    }
                }
            ).WithTags("Vehicle");

            app.MapPost
            (
                "/vehicle/create/:type/:mark/:model/:year",
                (string type, string mark, string model, int year) =>
                {
                    if (userSession.IsLogged) {
                        if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(mark) || string.IsNullOrEmpty(model) || year < 1990) {
                            return Results.BadRequest("Invalid input.");
                        } else {
                            try {
                                concessionaria.CreateVehicle(type, mark, model, year);
                                return Results.Ok("Vehicle created successfully");
                            } catch (Exception) {
                                return Results.BadRequest("Vehicle doesn't created");            
                            }
                        }                        
                    } else {
                        return Results.BadRequest("Authentication needed.");
                    }
                }
            ).WithTags("Vehicle");

            app.MapPut
            (
                "/vehicle/update/:id/:type/:mark/:model/:year",
                (int id, string type, string mark, string model, int year) =>
                {
                    if (userSession.IsLogged) {
                        if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(mark) || string.IsNullOrEmpty(model) || year < 1990) {
                            return Results.BadRequest("Invalid input.");
                        } else {
                            try {
                                var vehicle = concessionaria.UpdateVehicle(id, type, mark, model, year);

                                return Results.Ok("Vehicle updated successfully");
                            } catch (Exception) {
                                return Results.BadRequest("Vehicle id doesn't exist");
                            }
                        }
                    } else {
                        return Results.BadRequest("Authentication needed.");
                    }
                }
            ).WithTags("Vehicle");

            app.MapPatch
            (
                "/vehicle/update/:id",
                (int id, string? type, string? mark, string? model, int? year) =>
                {
                    if (userSession.IsLogged) {
                        if (id < 0 || (string.IsNullOrEmpty(type) && string.IsNullOrEmpty(mark) && string.IsNullOrEmpty(model) && year < 1990)) {
                            return Results.BadRequest("Invalid input.");
                        } else {
                             try {
                                var vehicle = concessionaria.UpdateVehicle(id, type, mark, model, year);

                                return Results.Ok("Vehicle updated successfully");
                            } catch (Exception) {
                                return Results.BadRequest("Vehicle id doesn't exist");  
                            }
                        }
                    } else {
                        return Results.BadRequest("Authentication needed.");
                    }
                }
            ).WithTags("Vehicle");

            app.MapDelete
            (
                "/vehicle/delete/:id",
                (int id) =>
                {
                    if (userSession.IsLogged) {
                        if (id < 0) {
                            return Results.BadRequest("Invalid input.");
                        } else {
                            if (concessionaria.DeleteVehicle(id)) return Results.Ok("Vehicle deleted successfully");
                            else return Results.BadRequest("Vehicle id doesn't exist");
                        }
                    } else {
                        return Results.BadRequest("Authentication needed.");
                    }
                }
            ).WithTags("Vehicle");
        }    
    }
}