﻿Module Module1
    Public Money As Integer = 10000
    Public UserInput As String
    Public Bet As Integer = 0
    Public BetString As String = ""
    Public A As Integer = 0
    Public NumberGen As New System.Random
    Public Dealer As Integer = 0
    Public StoreBet As Integer
    Sub Main()
        Do
            Dim MainInput As String
            Console.Clear()
            Console.Title = "Casino Games"
            Console.WriteLine("")
            Console.WriteLine("WELCOME!")
            Console.WriteLine("==========================")
            Console.WriteLine("Main Menu")
            Console.WriteLine("==========================")
            Console.WriteLine("1. Coin Flip")
            Console.WriteLine("2. Dice Roll")
            Console.WriteLine("3. Roulette")
            Console.WriteLine("4. Blackjack")
            Console.WriteLine("5. Slot Machine")
            Console.WriteLine("You currently have {0} credits!", Money)
            Console.WriteLine("==========================")
            Console.WriteLine("Enter your choice: ")
            MainInput = Console.ReadLine
            Select Case MainInput
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
                Case 5
                    SlotMachine()
                    Exit Do
                Case "memes"
                    Money = Money + 10000
                    Main()
                Case Else
                    Console.WriteLine("Please select an option from 1 to 5")
                    Console.ReadLine()
            End Select
        Loop

    End Sub

    Sub Coin()
        Console.Clear()
        Console.Title = "Coin Flip"
        Console.WriteLine("What do you want to bet it on, Heads or Tails (enter one of the two now)")
        BetString = Console.ReadLine
        If BetString = "Heads" Then
        ElseIf BetString = "Tails" Then
        ElseIf BetString = "¦" Then
        Else
            Invalid()
            Coin()
        End If

        If BetString = "¦" Then
            A = NumberGen.Next(1, 2)
            BetString = "Heads"
        Else
            A = NumberGen.Next(1, 3)
        End If

        DoBet()

        Console.Clear()
        Console.WriteLine("You have bet {0} credits on {1}, good luck!", Bet, BetString)

        If A = 1 Then
            Console.Clear()
            Console.WriteLine("The coin landed on Heads!")
            If BetString = "Heads" Or BetString = "¦" Then
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
        Console.Clear()
        Console.Title = "Dice Roll"
        Console.WriteLine("What do you want to bet it on, enter any number between 1 and 6 or Odd or Even (Case Sensititive)")
        BetString = Console.ReadLine

        If BetString < "7" And BetString > "0" Then
        ElseIf BetString = "Odd" Then
        ElseIf BetString = "Even" Then
        ElseIf BetString = "Ì" Then
        Else
            Invalid()
            Dice()
        End If

        DoBet()
        If BetString = "Ì" Then
            A = NumberGen.Next(1, 2)
            BetString = 1
        Else
            A = NumberGen.Next(1, 7)
        End If

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
            Console.Clear()
            Console.WriteLine("Congratulations, you won! You won {0} credits.", Bet)
        End If
        Home()
    End Sub
    Sub Roulette()
        Dim BetInteger
        Dim InputValid As Boolean = False
        Console.Clear()
        Console.Title = "Roulette"
        Console.WriteLine("What do you want to bet it on, enter any number from 1 to 36 now or alternatively, use Red or Black or Green (Case Sensitive).")
        BetString = Console.ReadLine
        If BetString = "▀" Then
            A = 0
            BetString = 0
            BetInteger = 0
            A = NumberGen.Next(0, 1)
        Else
            BetInteger = Val(BetString)
            A = NumberGen.Next(0, 37)
        End If
        If BetInteger < 37 And BetInteger >= 0 Then
            InputValid = True
        ElseIf BetString = "Red" Or BetString = "Black" Or BetString = "Green" Or BetString = "▀" Then
            InputValid = True
        End If

        If InputValid = False Then
            Invalid()
            Roulette()
        End If

        DoBet()

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
        Dim UseAuto As String
        Console.Clear()
        Console.Title = "Blackjack"
        Console.WriteLine("Welcome to Blackjack!")
        Console.WriteLine("Do you want to use the auto-bet feature? Y/N")
        UseAuto = Console.ReadLine
        If UseAuto = "Y" Then
            AutoBlackjack()
        ElseIf UseAuto = "N" Then
        Else
            Invalid()
            Blackjack()
        End If
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
    Sub SlotMachine()
        Console.Clear()
        Console.Title = "Slot Machine"
        Console.WriteLine("Welcome to Slots!")
        Console.WriteLine("Each bet will give you three spins.")
        Console.WriteLine("Do you want to use an autobet feature?" & vbCrLf & "1. Yes" & vbCrLf & "2. No")
        Dim AutoBet As String = Console.ReadLine()
        Select Case AutoBet
            Case 1
                AutoSlotMachine()
            Case 2
                DoBet()
            Case Else
                Console.WriteLine("That is invalid, press enter to return to the beginning of the Slot Machine now.")
                SlotMachine()
        End Select
        Dim Lines As Integer = 0
        Dim BetOG As Integer = Bet
        For Game = 0 To 2
            A = NumberGen.Next(1, 8)
            Dim I As Integer = NumberGen.Next(1, 8)
            Dim F As Integer = NumberGen.Next(1, 8)
            Dim C As Integer = NumberGen.Next(1, 8)
            Dim B As Integer = NumberGen.Next(1, 8)
            Dim H As Integer = NumberGen.Next(1, 8)
            Dim D As Integer = NumberGen.Next(1, 8)
            Dim G As Integer = NumberGen.Next(1, 8)
            Dim E As Integer = NumberGen.Next(1, 8)
            'Experimental "Jackpot" Stuff to give the user a chance of winning huge, probably needs to be a lot higher.
            Dim Jackpot As Integer = NumberGen.Next(1, 141)
            If Jackpot = 70 Then
                B = A
                C = A
                D = A
                E = A
                F = A
                G = A
                H = A
                I = A
            End If
            Dim SlotArray() As Integer = {A, B, C, D, E, F, G, H, I}
            DrawSlotTable(B, C, D, E, F, G, H, I)
            Console.WriteLine("")
            If A = B And B = C Then
                Lines = Lines + 16
            End If
            If D = E And E = F Then
                Lines = Lines + 1
            End If
            If G = H And H = I Then
                Lines = Lines + 1
            End If
            If A = D And D = G Then
                Lines = Lines + 1
            End If
            If B = E And E = H Then
                Lines = Lines + 1
            End If
            If C = F And F = I Then
                Lines = Lines + 1
            End If
        Next


        If Lines > 0 Then
            Console.WriteLine("Congratulations! You got {0} lines.", Lines)
            Bet = BetOG * 2
            Bet = Bet * Lines
            Money = Money + Bet
        Else
            Console.WriteLine("Oh no, you lost!")
        End If
        Home()
        Console.ReadLine()
    End Sub
    Sub AutoSlotMachine()
        Console.Clear()
        Console.Title = "Automatic Slot Machine"
        Console.WriteLine("How many rounds do you want to play?")
        Dim Rounds As String = Console.ReadLine
        Dim RoundsValid As Boolean = False
        Dim RoundsFinished As Boolean = False
        Dim Wins As Integer = 0
        Dim Jackpots As Integer = 0
        Dim RoundsTotal As Integer
        While RoundsValid = False
            If IsNumeric(Rounds) Or Rounds = "ß" Or Rounds = "ë" Then
                RoundsValid = True
            Else
                Console.WriteLine("That is not valid, enter a number now.")
                Rounds = Console.ReadLine
            End If
        End While
        Dim RoundsAmount As Integer
        If Rounds = "ß" Then
            RoundsAmount = 5
        ElseIf Rounds = "ë" Then
            RoundsAmount = 100
        Else
            RoundsAmount = Rounds
        End If
        DoBet()
        Dim BetOG As Integer = Bet
        Console.Clear()
        Console.WriteLine("Your spins are now being simulated as fast as possible, please wait.")
        For RoundsInt As Integer = 1 To RoundsAmount
            RoundsTotal = RoundsInt
            'Do Until RoundsFinished = True
            '    While RoundsFinished = False
            '        Console.Clear()
            '    End While
            '    If RoundsAmount = RoundsInt Then
            '    ElseIf Money = 0 Then
            '        RoundsFinished = True
            '    End If
            '    If BetOG > Money Then
            '        RoundsFinished = True
            '    End If
            'Loop
            If RoundsInt > 1 Then
                If Money - BetOG < 0 Then
                    Exit For
                Else

                    Money = Money - BetOG
                End If
            End If
            'Console.WriteLine("Round {0}", RoundsInt)
            Dim Lines As Integer
            Lines = 0
            For Game = 0 To 2

                A = NumberGen.Next(1, 8)
                Dim I As Integer = NumberGen.Next(1, 8)
                Dim F As Integer = NumberGen.Next(1, 8)
                Dim C As Integer = NumberGen.Next(1, 8)
                Dim B As Integer = NumberGen.Next(1, 8)
                Dim H As Integer = NumberGen.Next(1, 8)
                Dim D As Integer = NumberGen.Next(1, 8)
                Dim G As Integer = NumberGen.Next(1, 8)
                Dim E As Integer = NumberGen.Next(1, 8)
                'Experimental "Jackpot" Stuff to give the user a chance of winning huge, probably needs to be a lot higher.
                Dim Jackpot As Integer = NumberGen.Next(1, 131)
                If Jackpot = 65 Then
                    B = A
                    C = A
                    D = A
                    E = A
                    F = A
                    G = A
                    H = A
                    I = A
                    Jackpots = Jackpots + 1
                End If
                If Rounds = "ß" Or Rounds = "ë" Then
                    B = A
                    C = A
                    D = A
                    E = A
                    F = A
                    G = A
                    H = A
                    I = A
                    Jackpots = Jackpots + 1
                End If
                Dim SlotArray() As Integer = {A, B, C, D, E, F, G, H, I}
                'DrawSlotTable(B, C, D, E, F, G, H, I)
                'Console.WriteLine("")
                If A = B And B = C Then
                    Lines = Lines + 1
                End If
                If D = E And E = F Then
                    Lines = Lines + 1
                End If
                If G = H And H = I Then
                    Lines = Lines + 1
                End If
                If A = D And D = G Then
                    Lines = Lines + 1
                End If
                If B = E And E = H Then
                    Lines = Lines + 1
                End If
                If C = F And F = I Then
                    Lines = Lines + 1
                End If
            Next


            If Lines > 0 Then
                'Console.WriteLine("Congratulations! You got {0} lines.", Lines)
                Bet = BetOG * 2
                Bet = Bet * Lines
                Money = Money + Bet
                Wins = Wins + 1
                'Else
                '    Console.WriteLine("Oh no, you lost!")
            End If
        Next
        Console.Clear()
        Console.WriteLine("The spins are done! You won on {0} spins out of {1} with {2} jackpots!", Wins, RoundsTotal, Jackpots)
        Home()
        Console.ReadLine()
    End Sub
    Sub DrawSlotTable(ByVal B, C, D, E, F, G, H, I)
        Console.WriteLine("| {0} | {1} | {2} |", A, B, C)
        Console.WriteLine("| {0} | {1} | {2} |", D, E, F)
        Console.WriteLine("| {0} | {1} | {2} |", G, H, I)
    End Sub
    Sub DoBet()
        Console.Clear()
        Console.WriteLine("==========================")
        Console.WriteLine("Enter a bet amount now:")
        Console.WriteLine("==========================")
        Console.WriteLine("You currently have {0} credits!", Money)
        Console.WriteLine("==========================")

        Try
            Bet = Console.ReadLine
        Catch ex As Exception
            Invalid()
            DoBet()
        Finally
            StoreBet = Bet

            If Bet > Money Then
                Console.Clear()
                Console.WriteLine("You can not bet more than you have, please press enter to retry.")
                Console.ReadLine()
                DoBet()
            ElseIf Bet < 0 Then
                Console.Clear()
                Console.WriteLine("You can not bet less than 0, please press enter to retry.")
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
        'Money = Money + StoreBet
    End Sub
    Sub AutoBlackjack()
        Dim PlayerStand As Integer = 16
        Dim PlayerChange As Boolean = False
        Dim PlayerInput As String
        Dim Rounds As String
        Dim RoundsInt As Integer
        Dim RoundsTotal As Integer
        Dim Wins As Integer
        Dim Blackjacks As Integer
        Dim Draws As Integer
        Dim BetOG As Integer
        Console.Clear()
        Console.Title = "Automatic Blackjack"
        Console.WriteLine("Welcome to Automatic Blackjack!")
        Console.WriteLine("In this version an AI will play for you, which will always stand above a threshold you set.")
        Console.WriteLine("The current value for the threshold of standing is: {0}", PlayerStand)
        Console.WriteLine("Would you like to change that? Y/N")
        PlayerInput = Console.ReadLine.ToUpper
        Select Case PlayerInput
            Case "Y"
                Console.Clear()
                Console.WriteLine("What would you like the value to be?")
                PlayerStand = Console.ReadLine
                If PlayerStand > 0 And PlayerStand < 22 Then
                    Console.WriteLine("The input of {0} is valid! Good luck!")
                    Console.ReadLine()
                Else
                    Console.WriteLine("That is not a vaild input, start again.")
                    Console.ReadLine()
                    AutoBlackjack()
                End If
            Case "N"
                Console.Clear()
                Console.WriteLine("The lowest stand will be set as {0}, good luck!", PlayerStand)
                Console.ReadLine()
            Case Else
                Console.Clear()
                Console.WriteLine("Sorry, that is not a valid input. Try again!")
                Console.ReadLine()
                AutoBlackjack()
        End Select
        Console.WriteLine("How many rounds do you want to play?")
        Rounds = Console.ReadLine
        If IsNumeric(Rounds) Then
            RoundsInt = Convert.ToInt32(Rounds)
        Else
            Invalid()
            AutoBlackjack()
        End If
        DoBet()
        BetOG = Bet
        'Add loop for games
        Console.WriteLine("Your games are now being simulated as fast as possible, please wait.")
        For RoundsAmount = 0 To RoundsInt
            Bet = BetOG
            If RoundsAmount > 1 Then
                If Money - BetOG < 0 Then
                    Exit For
                Else
                    Money = Money - BetOG
                End If
            End If
            RoundsTotal = RoundsTotal + 1
            A = NumberGen.Next(1, 12) + NumberGen.Next(1, 12)
            If A = 22 Then
                A = 12
            End If

            'Console.WriteLine("You have been dealt {0}, would you like to hit? Y or N.", A)
            'BetString = Console.ReadLine

            'If BetString = "Y" Then
            'ElseIf BetString = "N" Then
            'Else
            '    Invalid()
            '    Blackjack()
            'End If

            If A >= PlayerStand Then
                BetString = "N"
            Else
                BetString = "Y"
            End If

            If BetString = "Y" Then
                If A < 22 Then
                    While BetString = "Y"
                        A = A + NumberGen.Next(1, 11)
                        If A > 21 Then
                            'Console.WriteLine("Oh no, you bust on {0}! Better luck next time.", A)
                            'Home()
                        End If
                        If A >= PlayerStand Then
                            BetString = "N"
                        Else
                            BetString = "Y"
                        End If
                        'Console.WriteLine("You now have a total of {0}, would you like to hit? Y or N.", A)
                        'BetString = Console.ReadLine()
                    End While
                End If
                If A > 21 Then
                    'Console.WriteLine("Oh no, you bust on {0}! Better luck next time.", A)
                    'Home()
                End If

                If A = 21 Then
                    Bet = Bet * 3
                    Money = Bet + Money
                    Wins = Wins + 1
                    Blackjacks = Blackjacks + 1
                    'Console.WriteLine("Congratulations, you got Blackjack winning you a total of {0}!", Bet)
                    'Home()
                End If
            End If

            If BetString = "N" Then
                'Console.WriteLine("You have stood on {0}, good luck!", A)
                Dealer = NumberGen.Next(1, 12) + NumberGen.Next(1, 12)
                If Dealer = 22 Then
                    Dealer = 12
                End If
                'Console.WriteLine("The dealer has {0}, press enter to continue.", Dealer)
                'Console.ReadLine()
                While Dealer < 17
                    Dealer = Dealer + NumberGen.Next(1, 12)
                    'Console.WriteLine("The dealer now has {0}, press enter to continue.", Dealer)
                    'Console.ReadLine()
                End While
                If Dealer > 16 Then
                    'Console.WriteLine("The dealer has stood on {0}!", Dealer)
                    If A > Dealer And A < 21 Then
                        'Console.WriteLine("Congratulations, you beat the dealer!")
                        Bet = Bet + Bet
                        Console.WriteLine("{0} {1}", Money, Bet)
                        Money = Bet + Money
                        Wins = Wins + 1
                        'Console.WriteLine("You have won {0} credits!", Bet)
                        'Home()
                    End If

                    If Dealer > 21 Then
                        'Console.WriteLine("Congratulations, you beat the dealer!")
                        Bet = Bet + Bet
                        Money = Bet + Money
                        Wins = Wins + 1
                        'Console.WriteLine("You have won {0} credits!", Bet)
                        'Home()
                    End If

                    If A < Dealer Then
                        'Console.WriteLine("Oh no, you have lost! You lost {0} credits.", Bet)
                        'Home()
                    End If

                    If A = Dealer Then
                        'Console.WriteLine("You and the dealer got the same amount! You got {0} credits back.", Bet)
                        Money = Bet + Money
                        Draws = Draws + 1
                        'Home()
                    End If
                End If
            End If
            'If A > 21 Then
            '    'Console.WriteLine("Oh no, you bust! Better luck next time.")
            '    Home()
            'End If
        Next
        Console.Clear()
        Console.WriteLine("The games are done! You won/drew in {0} games out of {1} with {2} blackjacks and {3} draws!", Wins + Draws, RoundsTotal, Blackjacks, Draws)
        Home()
        Console.ReadLine()
    End Sub
End Module
