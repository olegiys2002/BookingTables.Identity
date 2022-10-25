using BookingTables.Shared.RequestModels;
using Identity.Controllers;
using Identity.Core.DTOs;
using Identity.Core.IServices;
using Microsoft.AspNetCore.Mvc;
using Moq;


namespace API.Tests
{
    public class UserControllerTests
    {
        private readonly Mock<IUserService> _userService = new();
        private readonly Mock<UserRequest> userRequest = new();
  
        [Fact]
        public async Task UserController_GetUsers_ReturnOk()
        {

            var usersDTOs = new Mock<List<UserDTO>>();

            _userService.Setup(us => us.GetUsersAsync(userRequest.Object)).Returns(Task.FromResult(usersDTOs.Object));
            var userController = new UserController(_userService.Object);

            var result = await userController.GetUsers(userRequest.Object);

            Assert.IsType<OkObjectResult>(result as OkObjectResult);
        }

        [Fact]
        public async Task UserController_GetUsers_NotFound()
        {
            var usersDTOs = new List<UserDTO>();
            usersDTOs = null;
            _userService.Setup(us => us.GetUsersAsync(userRequest.Object)).Returns(Task.FromResult(usersDTOs));
            var userController = new UserController(_userService.Object);

            var result = await userController.GetUsers(userRequest.Object);

            Assert.IsType<NotFoundResult>(result as NotFoundResult);
        }

        [Fact]

        public async Task UserController_GetUserById_Ok()
        {
            var id = "";
            UserDTO userDTO = new UserDTO();
            _userService.Setup(us => us.GetUserByIdAsync(id)).Returns(Task.FromResult(userDTO));
            var userController = new UserController(_userService.Object);

            var result = await userController.GetUserById(id);

            Assert.IsType<OkObjectResult>(result as OkObjectResult);
        }
        [Fact]
        public async Task UserController_GetUserById_NotFound()
        {
            var id = "";
            UserDTO userDTO = null;
            _userService.Setup(us => us.GetUserByIdAsync(id)).Returns(Task.FromResult(userDTO));
            var userController = new UserController(_userService.Object);

            var result = await userController.GetUserById(id);

            Assert.IsType<NotFoundResult>(result as NotFoundResult);
        }

        [Fact]

        public async Task UserContoller_UpdateUser_NoContent()
        {
            var userFormDTO = new Mock<UserFormDTO>();
            var id = "";
            var resultUpdate = new UserDTO();
            _userService.Setup(us => us.UpdateUserAsync(id, userFormDTO.Object)).Returns(Task.FromResult(resultUpdate));
            var userController = new UserController(_userService.Object);

            var result = await userController.UpdateUser(id,userFormDTO.Object);

            Assert.IsType<NoContentResult>(result as NoContentResult);
        }

        [Fact]
        public async Task UserContoller_UpdateUser_NotFound()
        {
            var userFormDTO = new Mock<UserFormDTO>();
            var id = "";
            var resultUpdate = new UserDTO();
            _userService.Setup(us => us.UpdateUserAsync(id, userFormDTO.Object)).Returns(Task.FromResult(resultUpdate));
            var userController = new UserController(_userService.Object);

            var result = await userController.UpdateUser(id, userFormDTO.Object);

            Assert.IsType<NotFoundResult>(result as NotFoundResult);
        }
        [Fact]
        public async Task UserContoller_DeleteUser_NoContent()
        {
            var id = "";
            var resultUpdate = "";
            _userService.Setup(us => us.DeleteUserAsync(id)).Returns(Task.FromResult(resultUpdate));
            var userController = new UserController(_userService.Object);

            var result = await userController.DeleteUser(id);

            Assert.IsType<NoContentResult>(result as NoContentResult);
        }

        [Fact]
        public async Task UserContoller_DeleteUser_NotFound()
        {
            var id = "";
            var resultUpdate = "";
            _userService.Setup(us => us.DeleteUserAsync(id)).Returns(Task.FromResult(resultUpdate));
            var userController = new UserController(_userService.Object);

            var result = await userController.DeleteUser(id);

            Assert.IsType<NotFoundResult>(result as NotFoundResult);
        }



    }
}
