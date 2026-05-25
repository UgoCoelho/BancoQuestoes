def mergeSort(x):
    merge(x,0,len(x))
def merge(x,ini,fim):
    if fim - ini > 1:
        meio = (ini+fim)//2
        merge(x,ini,meio)
        merge(x,meio,fim)
        concatena(x,ini,meio,fim)
def concatena(x,ini,meio,fim):
    va=x[ini:meio]
    vb=x[meio:fim]
    ia = 0
    ib = 0
    for i in range(ini, fim):
        if ib == len(vb):
            x[i]=va[ia]
            ia = ia + 1
            continue
        if ia == len(va):
            x[i]=vb[ib]
            ib=ib+1
            continue
        if va[ia]<vb[ib]:
            x[i]=va[ia]
            ia=ia +1
        else:
            x[i]=vb[ib]
            ib= ib+1

n=[5,6,1,7,8,5,3,2]
mergeSort(n)
print(n)