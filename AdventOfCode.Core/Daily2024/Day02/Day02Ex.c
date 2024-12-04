// gcc test.c -o test -lm -g

#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <stdbool.h>

struct ReportNode {
    int reportNumber;
    struct ReportNode *next;
};

struct Report {
    struct ReportNode *reportNode;
    struct Report *next;
};

int readFullFile(char **fileContent)
{
    FILE *inputFile = fopen("input.txt", "r");
    
    fseek(inputFile, 0, SEEK_END);
    int inputFileLength = ftell(inputFile);
    fseek(inputFile, 0, SEEK_SET);
    
    *fileContent = malloc(inputFileLength * sizeof(char));
    fread(*fileContent, 1, inputFileLength, inputFile);

    fclose(inputFile);
    return inputFileLength;
}

void AddReportNumber(struct ReportNode **head, int number)
{
    struct ReportNode *newReportNumber = malloc(sizeof(struct ReportNode));
    newReportNumber->reportNumber = number;
    newReportNumber->next = NULL;

    if(*head == NULL)
    {
        *head = newReportNumber;
        return;
    }

    struct ReportNode *iteratorNode = *head;
    while (iteratorNode->next != NULL)
    {
        iteratorNode = iteratorNode->next;
    }
    iteratorNode->next = newReportNumber;
}

void AddReport(struct Report **head, struct ReportNode *reportNode)
{
    struct Report *newReport = malloc(sizeof(struct Report));
    newReport->reportNode = reportNode;
    newReport->next = NULL;

    if(*head == NULL)
    {
        *head = newReport;
        return;
    }

    struct Report *iteratorNode = *head;
    while (iteratorNode->next != NULL)
    {
        iteratorNode = iteratorNode->next;
    }
    iteratorNode->next = newReport;
}

struct Report* GetReportsFromInput(char *puzzleInput, int inputLength)
{
    struct Report *reportsHead = NULL;
    struct ReportNode *currentReportNodesHead = NULL;

    int buildedNumber = 0;
    int offsetInNumber = 0;
    for (int i = 0; i < inputLength; i++)
    {
        if(puzzleInput[i] == '\r')
            continue;

        if(puzzleInput[i] == '\n')
        {
            AddReportNumber(&currentReportNodesHead, buildedNumber);
            AddReport(&reportsHead, currentReportNodesHead);
            currentReportNodesHead = NULL;
            offsetInNumber = 0;
            buildedNumber = 0;
            continue;
        }

        if(puzzleInput[i] == ' ')
        {
            AddReportNumber(&currentReportNodesHead, buildedNumber);
            offsetInNumber = 0;
            buildedNumber = 0;
            continue;
        }

        int currentNumber = puzzleInput[i] - '0';
        buildedNumber = buildedNumber * pow(10, offsetInNumber) + currentNumber;
        offsetInNumber++;
    }

    if(puzzleInput[inputLength - 1] != '\n')
        AddReport(&reportsHead, currentReportNodesHead);

    return reportsHead;
}

bool IsSafe(struct ReportNode *reportNodeHead)
{
    bool isIncreasing = (reportNodeHead->next->reportNumber - reportNodeHead->reportNumber) > 0;
    int lastValue = reportNodeHead->reportNumber;
    struct ReportNode *temp = reportNodeHead->next;
    while(temp != NULL)
    {
        int distanceToLast = temp->reportNumber - lastValue;
        
        if(abs(distanceToLast) < 1 || abs(distanceToLast) > 3)
            return false;

        if(distanceToLast < 0 && isIncreasing || distanceToLast > 0 && !isIncreasing)
            return false;

        lastValue = temp->reportNumber;
        temp = temp->next;
    }
    return true;
}

void debugReports(struct Report* reportsHead)
{
    while (reportsHead != NULL)
    {
        struct ReportNode *node = reportsHead->reportNode;
        while (node != NULL)
        {
            printf("%d ", node->reportNumber);
            node = node->next;
        }
        reportsHead = reportsHead->next;
        printf("\n");
    }
}

void computePart1(char *puzzleInput, int inputLength)
{
    struct Report *reportsHead = GetReportsFromInput(puzzleInput, inputLength);
    //debugReports(reportsHead);

    struct Report *temp = reportsHead;
    int safeCount = 0;
    while (temp != NULL)
    {
        if(IsSafe(temp->reportNode))
        {
            safeCount++;
        }
        temp = temp->next;
    }
    printf("%d", safeCount);
}

int main(int argc, char const *argv[])
{
    char *content;
    int contentLength = readFullFile(&content);
    computePart1(content, contentLength);
    free(content);
    return 0;
}