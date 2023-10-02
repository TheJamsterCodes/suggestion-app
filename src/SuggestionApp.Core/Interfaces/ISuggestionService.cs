﻿namespace SuggestionApp.Core.Interfaces;

public interface ISuggestionService
{
    void AuthorSuggestion(Suggestion suggestion, User user);
    Task<Suggestion> Get(string id);
    Task<IEnumerable<Suggestion>> GetApprovedForRelease();
    Task<IEnumerable<Suggestion>> GetWaitingForApproval();
    bool Vote(Suggestion suggestion, User user, string votingUserId);
}
