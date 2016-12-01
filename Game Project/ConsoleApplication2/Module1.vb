Module Module1

    Sub Main()
        Do
            Dim intInput As Integer = 0
            Console.Clear()
            Console.WriteLine("")
            Console.WriteLine("WELCOME!")
            Console.WriteLine("==========================")
            Console.WriteLine("Main Menu")
            Console.WriteLine("==========================")
            Console.WriteLine("1. Coin Flip")
            Console.WriteLine("2. Dice Roll")
            Console.WriteLine("3. Roulette")
            Console.WriteLine("4. Blackjack")
            Console.WriteLine("You currently have {0} credits!", Money)
            Console.WriteLine("==========================")
            Console.WriteLine("Enter your choice: ")


            If Integer.TryParse(Console.ReadLine(), intInput) Then
                Select Case intInput
                    Case 1
                        Coin()
                        Exit Do
                    Case 2
                        Dice()
                        Exit Do
                    Case 3
                        Roulette()
                        Exit Do
                    Case 4
                        Blackjack()
                        Exit Do
                    Case Else
                        Console.WriteLine("Please select an option from 1 to 4")
                End Select
            Else
                Console.WriteLine("Please select an option from 1 to 4")
            End If
        Loop

    End Sub

    Sub Coin()
            DoBet()
            Console.Clear()
            Console.WriteLine("What do you want to bet it on, Heads or Tails (enter one of the two now)")
        BetString = Console.ReadLine
        If BetString = "Heads" Then
        ElseIf BetString = "Tails" Then
        Else
            Invalid()
            Coin()
        End If

            Console.Clear()
            Console.WriteLine("You have bet {0} credits on {1}, good luck!", Bet, BetString)

            A = NumberGen.Next(1, 3)

            If A = 1 Then
                Console.Clear()
                Console.WriteLine("The coin landed on Heads!")
                If BetString = "Heads" Then
                    Bet = Bet + Bet
                    Money = Bet + Money
                    Console.WriteLine("Congratulations, you won!")
                Else
                    Console.WriteLine("Oh no, you lost! Better luck next time.")
                End If
            End If

            If A = 2 Then
                Console.Clear()
                Console.WriteLine("The coin landed on Tails!")
                If BetString = "Tails" Then
                    Bet = Bet + Bet
                    Money = Bet + Money
                    Console.WriteLine("Congratulations, you won!")
                Else
                    Console.WriteLine("Oh no, you lost! Better luck next time.")
                End If
            End If
            Home()

    End Sub
    Sub Dice()
            DoBet()
            Console.Clear()
            Console.WriteLine("What do you want to bet it on, enter any number between 1 and 6 or Odd or Even (Case Sensititive)")
        BetString = Console.ReadLine

        If BetString < "7" And BetString > "0" Then
        ElseIf BetString = "Odd" Then
        ElseIf BetString = "Even" Then
        Else
            Invalid()
            Dice()
        End If

            A = NumberGen.Next(1, 7)
            If BetString = "Even" Then
                BetString = 100
            End If

            If BetString = "Odd" Then
                BetString = 200
            End If
            Console.Clear()
            If A Mod 2 = 0 Then
                Console.WriteLine("The dice rolled a {0} which is even!", A)
                If BetString = 100 Then
                    Bet = Bet * 2
                    Money = Money + Bet
                    Console.WriteLine("You won! You gained {0} credits.", Bet)
                Else
                    Console.WriteLine("Oh no, you lost! You lost {0} credits.", Bet)
                End If
            Else
                Console.WriteLine("The dice rolled a {0} which is odd!", A)
                If BetString = 200 Then
                    Bet = Bet * 2
                    Money = Money + Bet
                    Console.WriteLine("You won! You gained {0} credits.", Bet)
                Else
                    Console.WriteLine("Oh no, you lost! You lost {0} credits.", Bet)
                End If
            End If
            If A = BetString Then
                Bet = Bet * 6
                Money = Bet + Money
                Console.WriteLine("Congratulations, you won! You won {0} credits.", Bet)
            End If
            Home()
    End Sub
    Sub Roulette()
        Dim BetInteger
        Dim InputValid As Boolean = False
        DoBet()
        Console.Clear()
        Console.WriteLine("What do you want to bet it on, enter any number from 1 to 36 now or alternatively, use Red or Black or Green (Case Sensitive).")
        BetString = Console.ReadLine
        BetInteger = Val(BetString)

        If BetInteger < 37 And BetInteger >= 0 Then
            InputValid = True
        ElseIf BetString = "Red" Or BetString = "Black" Or BetString = "Green" Then
            InputValid = True
        End If

        If InputValid = False Then
            Invalid()
            Roulette()
        End If

        A = NumberGen.Next(0, 37)

        If BetString = "Black" Then
            BetString = 100
        End If

        If BetString = "Red" Then
            BetString = 200
        End If

        If BetString = "Green" Then
            BetString = 0
        End If

        If A Mod 2 = 0 Then
            Console.Clear()
            Console.WriteLine("The ball lands on {0} which is a black number!", A)
            If BetString = "100" Then
                Bet = Bet + Bet
                Money = Bet + Money
                Console.WriteLine("Congratulations, you bet correctly on Black! You won {0} credits.", Bet)
            End If

        Else
            Console.Clear()
            Console.WriteLine("The ball lands on {0} which is a red number!", A)
            If BetString = "200" Then
                Bet = Bet + Bet
                Money = Bet + Money
                Console.WriteLine("Congratulations, you bet correctly on Red! You won {0} credits.", Bet)
            End If
        End If

        If A = 0 Then
            Console.Clear()
            Console.WriteLine("The value generated was {0} which is green!", A)
            If BetInteger = 0 Then
                Bet = Bet * 36
                Money = Bet + Money
                Console.WriteLine("Congratulations, you bet correctly on Green! You won {0} credits.", Bet)
            End If
        End If

        If A = BetInteger And BetInteger > 0 Then
            Bet = Bet * 36
            Money = Bet + Money
            Console.WriteLine("WOW! You won a 1/36 chance! Congratulations! You won {0} credits", Bet)
        End If
        Home()
    End Sub
    Sub Blackjack()
            Console.Clear()
            Console.WriteLine("Welcome to Blackjack!")
            DoBet()
            A = NumberGen.Next(1, 12) + NumberGen.Next(1, 12)
        If A = 22 Then
            A = 12
        End If
            Console.WriteLine("You have been dealt {0}, would you like to hit? Y or N.", A)
        BetString = Console.ReadLine
        If BetString = "Y" Then
        ElseIf BetString = "N" Then
        Else
            Invalid()
            Blackjack()
        End If
            If BetString = "Y" Then
                If A < 22 Then
                    While BetString = "Y"
                        A = A + NumberGen.Next(1, 11)
                        If A > 21 Then
                            Console.WriteLine("Oh no, you bust on {0}! Better luck next time.", A)
                            Home()
                        End If
                        Console.WriteLine("You now have a total of {0}, would you like to hit? Y or N.", A)
                        BetString = Console.ReadLine()
                    End While
                End If
                If A > 21 Then
                    Console.WriteLine("Oh no, you bust on {0}! Better luck next time.", A)
                    Home()
                End If

                If A = 21 Then
                    Bet = Bet * 3
                    Money = Bet + Money
                    Console.WriteLine("Congratulations, you got Blackjack winning you a total of {0}!", Bet)
                    Home()
                End If
            End If

            If BetString = "N" Then
                Console.WriteLine("You have stood on {0}, good luck!", A)
                Dealer = NumberGen.Next(1, 12) + NumberGen.Next(1, 12)
                If Dealer = 22 Then
                    Dealer = 12
                End If
                Console.WriteLine("The dealer has {0}, press enter to continue.", Dealer)
                Console.ReadLine()
                While Dealer < 17
                    Dealer = Dealer + NumberGen.Next(1, 12)
                    Console.WriteLine("The dealer now has {0}, press enter to continue.", Dealer)
                    Console.ReadLine()
                End While
                If Dealer > 16 Then
                    Console.WriteLine("The dealer has stood on {0}!", Dealer)
                    If A > Dealer And A < 21 Then
                        Console.WriteLine("Congratulations, you beat the dealer!")
                        Bet = Bet + Bet
                        Money = Bet + Money
                        Console.WriteLine("You have won {0} credits!", Bet)
                        Home()
                    End If

                    If Dealer > 21 Then
                        Console.WriteLine("Congratulations, you beat the dealer!")
                        Bet = Bet + Bet
                        Money = Bet + Money
                        Console.WriteLine("You have won {0} credits!", Bet)
                        Home()
                    End If

                    If A < Dealer Then
                        Console.WriteLine("Oh no, you have lost! You lost {0} credits.", Bet)
                        Home()
                    End If

                    If A = Dealer Then
                        Console.WriteLine("You and the dealer got the same amount! You got {0} credits back.", Bet)
                        Money = Bet + Money
                        Home()
                    End If
                End If
            End If
            If A > 21 Then
                Console.WriteLine("Oh no, you bust! Better luck next time.")
                Home()
            End If
    End Sub
    Public Money As Integer = 10000
    Public UserInput As String
    Public Bet As Integer = 0
    Public BetString As String = ""
    Public A As Integer = 0
    Public NumberGen As New System.Random
    Public Dealer As Integer = 0
    Public StoreBet As Integer
    Sub DoBet()
        Console.Clear()
        Console.WriteLine("==========================")
        Console.WriteLine("Enter a bet amount now:")
        Console.WriteLine("==========================")
        Console.WriteLine("You currently have {0} credits!", Money)
        Console.WriteLine("==========================")

        BetString = Console.ReadLine()

        Try
            Bet = Convert.ToInt32(BetString)
        Catch ex As Exception
            Invalid()
            DoBet()
        Finally
            StoreBet = BetString

            If Bet > Money Then
                Console.Clear()
                Console.WriteLine("You can not bet more than you have, please press enter to retry.")
                Console.ReadLine()
                DoBet()
            Else
                Money = Money - Bet
            End If


        End Try



    End Sub
    Sub Home()
        Console.WriteLine("==========================")
        Console.WriteLine("You now have {0} credits left.", Money)
        Console.WriteLine("Press Enter to return to the main menu now.")
        Console.WriteLine("==========================")
        Console.ReadLine()
        Lose()
        Main()
    End Sub
    Public Sub Lose()
        If Money <= 0 Then
            Console.Clear()
            Console.WriteLine("You currently have {0} credits :(", Money)
            Console.WriteLine("You LOSE!")
            Console.WriteLine("Press enter to quit now. Thanks for playing!")
            Console.ReadLine()
            Environment.Exit(0)
        End If
    End Sub
    Sub Invalid()
        Console.WriteLine("That is not a valid input, press enter to return to the start.")
        Console.ReadLine()
        Money = Money + StoreBet
    End Sub
End Module
