# Entities

### Category
- CategoryId
- Name
- Description

### Status
- StatusId
- Name
- Description

## Suggestion
- SuggestionId
- Description
- Title
- DateCreated
- DateUpdated?
- UpdatedBy?
- Category
- Status
    - NOTE:
      Status is different from the IsApproved boolean
      For instance, a suggestion can have the status, "Watching",
      but also eventually be false for IsApproved.
- CreatedBy
- Votes
- Notes
- IsApproved *(boolean)*
    - NOTE: See Status

### User
- ObjectId *(from Azure Active Diretory B2C)*
- UserId
- FirstName
- LastName
- DisplayName
- Email
- AuthoredSuggestions
- VotedOnSuggestions