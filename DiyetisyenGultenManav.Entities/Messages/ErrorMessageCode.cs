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
        BlogYazısıIsNotFound = 203,
        BlogYazısıTitleAlreadyExists = 204,
        BlogYazısıIsNotInserted = 205,
        BlogYazısıCouldNotRemove = 206,
        // Diet
        DietIsNotFound = 301,
        DietCouldNotRemove = 302,
    }
}
