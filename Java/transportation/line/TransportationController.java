package transportation.line;
import java.util.*;
import java.util.stream.*;

public class TransportationController implements Cloneable, Comparable<TransportationController> {
	// TODO adattag
	private HashMap<String, Set<Integer>> repairs;

	public void readLines(Scanner sc) throws TransportationException{
		repairs = new HashMap<>();

		int repairCount = sc.nextInt();

		for (int i = 0; i <= repairCount; i++) {
			String line = sc.nextLine();
			String[] split = line.split(" ");

			if (split.length == 3){
				String lineToInsert = split[0];
				int from = Integer.parseInt(split[1]);
				int to = Integer.parseInt(split[2]);

				Set<Integer> lineElems; //= repairs.get(lineToInsert);

				if (repairs.get(lineToInsert) == null) lineElems = new HashSet<>();
				else lineElems = repairs.get(lineToInsert);

				for (int j = from; j <= to; j++) {
					if (lineElems.contains(j)) throw new TransportationException("Line " + lineToInsert + " already contains element " + j);
					lineElems.add(j);
				}
				repairs.put(lineToInsert, lineElems);
			}
		}
	}

	public int getNumberOfLines() {
		return repairs.size();
	}
	
	public int sizeOf(String route) throws TransportationException {
		HashSet<Integer> elements = (HashSet)repairs.get(route);
		if (elements != null) {
			return elements.size();
		} else {
			throw new TransportationException("Line " + route + " is unknown");
		}
	}

	public boolean isUnderRepair(String route, int section) {
		if (repairs.get(route) != null) {
			return repairs.get(route).contains(section);
		} else return false;
	}

	public boolean isOperational(String route, int sectionStart, int sectionEnd) {
		HashSet<Integer> elements = (HashSet)repairs.get(route);
		if (elements != null) {
			boolean useable = true;
			for(int i = sectionStart; i <= sectionEnd && useable; ++i) {
				if(elements.contains(i)) {
					useable = false;
				}
			}
			return useable;
		} else return false;
	}

	@SuppressWarnings("unchecked")
	@Override public boolean equals(Object that) {
		if (that == this) return true;
		if (that == null) return false;

		if(that instanceof TransportationController) {
			TransportationController thatTC = (TransportationController)that;
			return this.repairs.equals(thatTC.repairs);
		}
		return false;
	}

	@Override public int hashCode(){
		return Objects.hash(this.repairs);
	}

	@Override public TransportationController clone(){
		try { 
			TransportationController that = (TransportationController)super.clone();
			that.repairs = new HashMap(that.repairs);
			return that;
		}
		catch (CloneNotSupportedException e) { return null;}
	}

	@Override public int compareTo(TransportationController that) {
		if(that == null) {
			throw new IllegalArgumentException();
		}
		if (that == this) {
			return 0;
		}

		if (this.repairs.size() > that.repairs.size()) {
			return 1;
		} else if (this.repairs.size() < that.repairs.size()) {
			return -1;
		} else {
			List<String> thisRoutes = new ArrayList<>();
			List<String> thatRoutes = new ArrayList<>();
			thisRoutes = this.repairs.keySet().stream().collect(Collectors.toList());
			thatRoutes = that.repairs.keySet().stream().collect(Collectors.toList());
			Collections.sort(thisRoutes);
			Collections.sort(thatRoutes);
			if (thisRoutes.equals(thatRoutes)) {
				for(int i = 0; i < thisRoutes.size(); ++i) {
					int a = this.repairs.get(thisRoutes.get(i)).size();
					int b = that.repairs.get(thisRoutes.get(i)).size();
					if( a != b ) {
						return Integer.compare(a, b) * (-1);
					}
				}
				return 0;
			} else {
				int i = 0;
				while( i != thisRoutes.size() ) {
					if(thisRoutes.get(i) != thatRoutes.get(i)) {
						break;
					}
					else {
						++i;
					}
				}
				return thisRoutes.get(i).compareTo(thatRoutes.get(i));
			}
		}
	}
}
