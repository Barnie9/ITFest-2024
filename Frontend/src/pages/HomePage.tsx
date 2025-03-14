import { FaRegFileAlt } from "react-icons/fa";

const HomePage = () => {
	return (
		<div className={"flex w-full flex-col items-center gap-10 pb-10"}>
			<img
				src={"/HomePagePhoto.png"}
				alt={"Home Page"}
				className={"h-[50vh] w-full object-cover"}
			/>

			<div
				className={
					"flex w-full flex-col items-center gap-4 px-5 md:px-20"
				}
			>
				<div className={"text-center text-4xl font-bold"}>
					Ce este Code Club?
				</div>

				<div className={"w-full text-justify text-xl font-bold"}>
					Lorem ipsum dolor sit amet, consectetur adipiscing elit.
					Lorem ipsum dolor sit amet, consectetur adipiscing elit.
					Lorem ipsum dolor sit amet, consectetur adipiscing elit.
					Lorem ipsum dolor sit amet, consectetur adipiscing elit.
					Lorem ipsum dolor sit amet, consectetur adipiscing elit.
					Lorem ipsum dolor sit amet, consectetur adipiscing elit.
					Lorem ipsum dolor sit amet, consectetur adipiscing elit.
				</div>

				<div className={"w-full text-justify text-xl font-bold"}>
					Lorem ipsum dolor sit amet, consectetur adipiscing elit.
					Lorem ipsum dolor sit amet, consectetur adipiscing elit.
					Lorem ipsum dolor sit amet, consectetur adipiscing elit.
					Lorem ipsum dolor sit amet, consectetur adipiscing elit.
					Lorem ipsum dolor sit amet, consectetur adipiscing elit.
					Lorem ipsum dolor sit amet, consectetur adipiscing elit.
					Lorem ipsum dolor sit amet, consectetur adipiscing elit.
				</div>
			</div>

			<div
				className={
					"flex w-[70%] flex-col items-center gap-4 rounded-3xl bg-apple p-8"
				}
			>
				<div className={"text-4xl font-bold text-white"}>
					Ateliere disponibile
				</div>

				{/* Cardurile pentru ateliere */}
			</div>

			{/* Sa apara doar daca sunt deschise inscrierile / sa fie disabled ??? */}
			<div
				className={
					"flex cursor-pointer items-center justify-center gap-2 rounded-2xl bg-apple px-10 py-6 shadow-around"
				}
			>
				<FaRegFileAlt className={"h-10 w-10"} />

				<div className={"text-4xl font-bold"}>Inscrie-te acum!</div>
			</div>
		</div>
	);
};

export default HomePage;
