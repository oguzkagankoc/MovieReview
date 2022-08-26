namespace Business.Services
{
    //public interface IUserService
    //{
    //    Result<UserModel> Giris(UserGirisModel model);
    //    Result Kayit(UserKayitModel model);
    //}

    //public class UserService : IUserService
    //{
    //    private readonly IUserService _userService;
    //    public UserService(IUserService userService)
    //    {
    //        _userService = userService;
    //    }
    //    public Result<UserModel> Giris(UserLoginModel model)
    //    {
    //        UserModel kullanici = _userService.Query().SingleOrDefault(k => k.KullaniciAdi == model.KullaniciAdi && k.Sifre == model.Sifre && k.AktifMi);
    //        if (kullanici == null)
    //            return new ErrorResult<UserModel>("Invalid username and password!");
    //        return new SuccessResult<KUserModel>(kullanici);
    //    }
    //    public Result Register(UserRegisterModel model)
    //    {
    //        var kullanici = new UserModel()
    //        {

                
    //            //AktifMi = true,
    //            //RolId = model.Rol == 0 ? (int)Rol.Kullanici : (int)model.Rol, // 0 geliyorsa kullanıcı gelmiyorsa gelen değeri setler.
    //            //KullaniciAdi = model.KullaniciAdi,
    //            //Sifre = model.Sifre,
    //            //ePosta = model.ePosta,
    //        };
    //        return _userService.Add(kullanici);
    //    }
    //}
}