def buscaSequencial(x,v):
    n=len(x)
    for i in range(0,n):
        if x[i] == v:
            return i
    return -1
a=[1,5,3,4]
print(buscaSequencial(a,5))

def buscaBinaria(x,v):
    n=len(x)
    li=0
    ls=n-1
    while li <= ls:
        media = (li+ls)//2
        if v == x[media]:
            return media
        elif v < x[media]:
            ls = media - 1
        else:
            li = media + 1
b=[1,2,3,4]
print(buscaBinaria(a,1))

def bubbleSort(x):
    n=len(x)
    for i in range(0,n-1):
        for j in range(n-1, i, -1):
            if x[j-1] > x[j]:
                x[j-1], x[j] = x[j], x[j-1]
    return x

c=[2,4,8,9,7,5]
print(bubbleSort(c))

def insertionSort(x):
    n=len(x)
    for i in range(1,n):
        atual = x[i]
        j = i 
        while j > 0 and x[j-1] > atual:
            x[j] = x[j-1]
            j = j - 1
        x[j] = atual
    return x

d=[4,2,1,6,8]
print(insertionSort(d))

def selectionSort(x):
    n=len(x)
    for i in range(0,n-1):
        for j in range(i+1,n):
            if x[i] > x[j]:
                x[i], x[j] = x[j], x[i]
    return x

e=[4,1,5,2,3,6]
print(selectionSort(e))

def shellSort(x):
    n=len(x)
    h=1
    while h<n:
        h=h*3+1
    while h>1:
        h=h//2
        for i in range(h,n,h):
            atual=x[i]
            j= i-h
            while j>=0 and atual < x[j]:
                x[j+h] = x[j]
                j = j- h
            x[j+h]=atual
    return x 

f=[4,1,5,7,2,3,8]
print(shellSort(f))

def mergeSort(x):
    merge(x,0,len(x))
    return x
def merge(x,ini,fim):
    if fim - ini > 1:
        meio = (ini+fim)//2
        merge(x,ini,meio)
        merge(x,meio,fim)
        concatena(x,ini,meio,fim)
def concatena(x,ini,meio,fim):
    va = x[ini:meio]
    vb = x[meio:fim]
    ia = 0
    ib = 0

    for i in range(ini,fim):
        if len(va) == ia:
            x[i] = vb[ib]
            ib += 1
            continue
        if len(vb) == ib:
            x[i] = va[ia]
            ia +=1
            continue
        if va[ia] < vb[ib]:
            x[i] = va[ia]
            ia +=1
            continue
        else:
            x[i] = vb[ib]
            ib +=1

g=[4,1,5,3,8,2]
print(mergeSort(g))

def geraHeap(vet,i,n):
    indMaior = i
    indFE = i*2+1
    indFD = i*2+2

    if indFE < n and vet[indFE] > vet[indMaior]:
        indMaior = indFE
    if indFD < n and vet[indFD] > vet[indMaior]:
        indMaior = indFD
    if indMaior != i:
        vet[i], vet[indMaior] = vet[indMaior], vet[i]
        geraHeap(vet,indMaior,n)

def heapSort(x):
    n=len(x)
    for i in range(n//2 - 1,-1,-1):
        geraHeap(x,i,n)
    for i in range(n-1,0,-1):
        x[i], x[0] = x[0], x[i]
        geraHeap(x,0,i)
    return x

h=[7,1,5,4,3,8,0]
print(heapSort(h))
