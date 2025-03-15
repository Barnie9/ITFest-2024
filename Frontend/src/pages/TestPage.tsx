import { ChangeEvent, useEffect, useState } from "react";
import useTestContext, {
	BadgeInputModel,
	BadgeModel,
} from "../context/TestContext";

const TestPage = () => {
	const { createBadge, getAllBadges } = useTestContext();

	const [badge, setBadge] = useState<BadgeInputModel>({
		name: "Python1",
		baseName: "python1",
		level: "Beginner",
		icon: "",
	});

	const [svgIcons, setSvgIcons] = useState<string[]>([]);

	useEffect(() => {
		const fetchBadges = async () => {
			const badges = await getAllBadges();
			const icons = badges.map((badge: BadgeModel) => badge.icon);
			setSvgIcons(icons);
		};
		fetchBadges();
	}, [getAllBadges]);

	const handleSvgUpload = (event: ChangeEvent<HTMLInputElement>) => {
		const file = event.target.files?.[0];
		if (file) {
			const reader = new FileReader();
			reader.onload = (e) => {
				const svgString = e.target?.result as string;
				console.log(svgString);
				setBadge((prevBadge) => ({ ...prevBadge, icon: svgString }));
			};
			reader.readAsText(file);
		}
	};

	return (
		<div className={"flex w-full flex-col items-center gap-2"}>
			<input type="file" accept=".svg" onChange={handleSvgUpload} />
			<button onClick={async () => await createBadge(badge)}>Send Request</button>

			<div className="flex flex-wrap w-full gap-2">
				{svgIcons.map((icon, index) => (
					<div
						className={"scale-[0.25]"}
						key={index}
						dangerouslySetInnerHTML={{ __html: icon }}
					/>
				))}
			</div>
		</div>
	);
};

export default TestPage;
