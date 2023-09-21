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
- IsApprovedForRelease *(boolean)*
    - NOTE: See Status
- IsArchived
    - When a suggestion is archived or not. Rejected suggestions can be archived.
- IsRejected
    - When a suggestion is eventually rejected regardless or status or even if it was approved for release.

### BasicSuggestion *(value object)*
- Id
- Title

### User
- ObjectId *(from Azure Active Diretory B2C)*
- UserId
- FirstName
- LastName
- DisplayName
- Email
- AuthoredSuggestions *(BasicSuggestion value object)*
- VotedOnSuggestions *(BasicSuggestion value object)*

### BasicUser *(value object)*
- Id
- DisplayName