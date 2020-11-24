namespace DiyetisyenGultenManav.Entities.Messages
{
    public enum ErrorMessageCode
    {
        UsernameAlreadyExists = 101,
        EmailAlreadyExists = 102,
        UserIsNotActive = 151,
        UsernameOrPassWrong = 152,
        CheckYourEmail = 153,
        UserAlreadyActive = 154,
        ActivateIdDoesNotExists = 155,
        UserIsNotFound = 156,
        userCouldNotUpdated = 157,
        UserCouldNotRemove = 158,
        userCouldNotInserted = 159,
        // Blog Yazısı 
        BlogYazisiTitleAlreadyExists = 201,
        BlogYazisiCouldNotUpdated = 202,
        BlogYazısıTitleAlreadyExists = 203,
        BlogYazısıIsNotInserted = 204,
        BlogYazısıCouldNotRemove = 205,
        // Diet
        DietIsNotFound = 301,
        DietCouldNotRemove = 302,
        WriteAnewDiet = 303,
        DietCouldNotUpdated = 304,
        DietIsNotInserted = 305,
        // Kategori
        KategoriIsNotFound = 401,
        KategoriTitleAlreadyExists = 402,
        KategoriCouldNotUpdated = 403,
        KategoriIsNotInserted = 404,
        // Paket
        PaketIsNotFound = 501,
        PaketCouldNotRemove = 502,
        PaketCouldNotUpdated = 503,
        PaketIsNotInserted = 504,
        // Contact
        ContactIsNotFound = 601,
        ContactCouldNotRemove = 602,
        ContactCouldNotUpdated = 603,
        ContactMesajAlreadyExists = 604,
        ContactIsNotInserted = 605,
        // Ödeme Bildirimi
        OdemeBildirimiIsNotFound = 701,
        OdemeBildirimiCouldNotRemove = 702,
    }
}
