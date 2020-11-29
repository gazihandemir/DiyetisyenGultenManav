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
        OdemeBildirimiIsNotInserted = 204,
        BlogYazısıCouldNotRemove = 205, 
        BlogYazısıIsNotFound = 206,
        BlogYazisiSayiCouldNotUpdated = 207,
        // Diet
        DietIsNotFound = 301,
        DietCouldNotRemove = 302,
        WriteAnewDiet = 303,
        DietCouldNotUpdated = 304,
        DietIsNotInserted = 305,
        DietİsnewNotUpdated = 306,
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
        OdemeBildirimiAdminCouldNotUpdated = 703,
        OdemeBildirimiUserCouldNotUpdated = 704,
        OdemeBildirimiIdAlreadyExists = 705,
        // Paket Talebi
        PaketTalebiIsNotFound = 801,
        PaketTalebiCouldNotRemove = 802,
        PaketTalebiEkAciklamalarAlreadyExists = 803,
        PaketTalebiCouldNotUpdated = 804,
        PaketTalebiIsNotInserted = 805,
    }
}
