            public bool Evaluate(EvaluationContext evaluationContext, ref object state)
            {
                bool bRet = false;
                CustomAuthState customstate = null;

                // If state is null, then this method has not been called before, so 
                // set up a custom state.
                if (state == null)
                {
                    customstate = new CustomAuthState();
                    state = customstate;
                }
                else
                    customstate = (CustomAuthState)state;

                Console.WriteLine("Inside MyAuthorizationPolicy::Evaluate");

                // If claims have not been added yet...
                if (!customstate.ClaimsAdded)
                {
                    // Create an empty list of Claims.
                    IList<Claim> claims = new List<Claim>();

                    // Iterate through each of the claim sets in the evaluation context.
                    foreach (ClaimSet cs in evaluationContext.ClaimSets)
                        // Look for Name claims in the current claim set.
                        foreach (Claim c in cs.FindClaims(ClaimTypes.Name, Rights.PossessProperty))
                            // Get the list of operations the given username is allowed to call.
                            foreach (string s in GetAllowedOpList(c.Resource.ToString()))
                            {
                                // Add claims to the list.
                                claims.Add(new Claim("http://example.org/claims/allowedoperation", s, Rights.PossessProperty));
                                Console.WriteLine("Claim added {0}", s);
                            }

                    // Add claims to the evaluation context.
                    evaluationContext.AddClaimSet(this, new DefaultClaimSet(this.Issuer,claims));

                    // Record that claims have been added.
                    customstate.ClaimsAdded = true;

                    // Return true, which indicates this need not be called again.
                    bRet = true;
                }
                else
                {
                    // This point should not be reached, but just in case...
                    bRet = true;
                }


                return bRet;
            }