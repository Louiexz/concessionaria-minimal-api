using API.Services;

namespace API.Controller {
    public class UserController {
        protected dynamic manager = new UserManager();

        public UserController(WebApplication app, dynamic userSession)
        {
            app.MapPost
            (
                "/user/login",
                (string email, string password) => {
                    if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)){
                        return Results.BadRequest("Bad credentials.");
                    } else {
                        userSession.IsLogged = manager.Login(email, password);

                        if (userSession.IsLogged) {
                            return Results.Ok("User logged succesfully");
                        } else {
                            return Results.BadRequest("Authentication failed.");
                        }
                    }                    
                }
            ).WithTags("Authentication");

            app.MapPost
            (
                "/user/logout",
                () => {
                    if (userSession.IsLogged) {
                        userSession.IsLogged = false;
                        return Results.Ok("User logged out succesfully");
                    } else {
                        return Results.BadRequest("User isn't logged");
                    }                    
                }
            ).WithTags("Authentication");

            app.MapGet
            (
                "/user/get/:id",
                (int id) =>
                {
                    if (id < 0){
                        return Results.BadRequest("Invalid id.");
                    } else {
                        if (userSession.IsLogged) {
                            try {
                                var user = manager.GetUser(id);
                                return Results.Ok($"User email: {user.email}\nUser password: *****");
                            } catch (Exception) {
                                return Results.NotFound("No user yet!");            
                            }
                        } else {
                            return Results.BadRequest("Authentication needed.");
                        }
                    }
                }
            ).WithTags("User");

            app.MapPost
            (
                "/user/create/:email/:password",
                (string email, string password) =>
                {
                    if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)){
                        return Results.BadRequest("Bad credentials.");
                    } else {
                        try {
                            manager.CreateUser(email, password);
                            return Results.Ok("User created succesfully");
                        } catch (Exception) {
                            return Results.NotFound("User doesn't created");
                        }
                    }        
                }
            ).WithTags("User");

            app.MapPut
            (
                "/user/update/:id/:email/:password",
                (int id, string email, string password) =>
                {
                    if (userSession.IsLogged) {
                        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || id >= 0) {
                            try {
                                var user = manager.UpdateUser(id, email, password);

                                return Results.Ok("User updated succesfully");
                            } catch (Exception) {
                                return Results.BadRequest("User id doesn't exist");
                            }
                        } else {
                            return Results.BadRequest("Invalid input.");
                        }
                    } else {
                        return Results.BadRequest("Authentication needed.");
                    }
                }
            ).WithTags("User");

            app.MapPatch
            (
                "/user/update/:id",
                (int id, string? email, string? password) =>
                {
                    if (userSession.IsLogged) {
                        if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(password) || id >= 0) {
                            try {
                                var user = manager.UpdateUser(id, email, password);

                                return Results.Ok("User updated succesfully");
                            } catch (Exception) {
                                return Results.BadRequest("User id doesn't exist");
                            }    
                        } else {
                            return Results.BadRequest("Invalid input.");
                        }
                        
                    } else {
                        return Results.BadRequest("Authentication needed.");
                    }
                }
            ).WithTags("User");

            app.MapDelete
            (
                "/user/delete/:id",
                (int id) =>
                {
                    if (userSession.IsLogged) {
                        if (id > 0) {
                            try {
                                manager.DeleteUser(id);
                                userSession.IsLogged = false;
                                return Results.NoContent();    
                            } catch (Exception) {
                                return Results.BadRequest("User id doesn't exist");
                            }    
                        } else {
                            return Results.BadRequest("Invalid input.");
                        }                                 
                    } else {
                        return Results.BadRequest("Authentication needed.");
                    }
                }
            ).WithTags("User");
        }    
    }
}