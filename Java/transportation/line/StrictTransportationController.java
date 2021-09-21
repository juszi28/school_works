package transportation.line;

import java.util.Scanner;
import java.util.TreeSet;
import java.util.HashMap;
import java.util.Set;

public class StrictTransportationController extends TransportationController {
	// TODO adattag
	private HashMap<String, Set<Integer>> repairs;

	@Override public void readLines(Scanner sc) throws TransportationException{
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

				if (repairs.get(lineToInsert) == null) lineElems = new TreeSet<>();
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
	
	@Override public int sizeOf(String route) throws TransportationException {
		TreeSet<Integer> elements = (TreeSet)repairs.get(route);
		if (elements != null) {
			return elements.floor(Integer.MAX_VALUE) - elements.ceiling(Integer.MIN_VALUE) + 1;
		} else {
			throw new TransportationException("Line " + route + " is unknown");
		}
	}

	@Override public boolean isUnderRepair(String route, int section) {
		TreeSet<Integer> elements = (TreeSet)repairs.get(route);
		if (elements != null) {
			int minSection = elements.ceiling(Integer.MIN_VALUE);
			int maxSection = elements.floor(Integer.MAX_VALUE);
			return (section >= minSection && section <= maxSection);
		} else return false;
	}

	@Override public boolean isOperational(String route, int sectionStart, int sectionEnd) {
		TreeSet<Integer> elements = (TreeSet)repairs.get(route);
		if (elements != null) {
			boolean useable = true;
			int minSection = elements.ceiling(Integer.MIN_VALUE);
			int maxSection = elements.floor(Integer.MAX_VALUE);
			for(int i = sectionStart; i <= sectionEnd && useable; ++i) {
				if(i >= minSection && i <= maxSection) {
					useable = false;
				}
			}
			return useable;
		} else return false;
	}

}
