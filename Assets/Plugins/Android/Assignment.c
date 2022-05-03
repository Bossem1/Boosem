#include<stdio.h> 
#include<conio.h>

void main()
{
    int i;  
    printf("The numbers divisible by 3 and 5 are: "); 
    for(int i = 200; i <= 300; i++) 
    {
        if (i % 5 == 0 )
        {
            printf("%d\n", i);
        }
    }
}